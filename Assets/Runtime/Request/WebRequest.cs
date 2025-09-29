/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  WebRequest.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/19
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

namespace MGS.Request
{
    public abstract class WebRequest<T> : IWebRequest<T>
    {
        public string Url { set; get; }

        public int TimeOut { set; get; }

        public T Result { get; protected set; }

        public bool IsDone { get; protected set; }

        public float Progress { get; protected set; }

        public Exception Error { get; protected set; }

        public event Action<float> OnProgressed;
        public event Action<T, Exception> OnCompleted;

        protected IDictionary<string, string> headers;
        protected UnityWebRequest request;

        public WebRequest(string url, int timeOut, IDictionary<string, string> headers = null)
        {
            Url = url;
            TimeOut = timeOut;
            this.headers = headers;
        }

        public virtual void ExecuteAsync() { }

        public IEnumerator WaitDone()
        {
            if (request == null)
            {
                Reset();
                using (request = CreateWebRequest(Url, headers))
                {
                    var operation = request.SendWebRequest();
                    while (!operation.isDone)
                    {
                        if (Progress != operation.progress)
                        {
                            Progress = operation.progress;
                            InvokeOnProgressed(Progress);
                        }
                        yield return null;
                    }
                    var success = operation.webRequest.result == UnityWebRequest.Result.Success;
                    Result = success ? ReadResult(operation.webRequest) : default;
                    Error = success ? default : new Exception(operation.webRequest.error);
                }
                request = null;
                InvokeOnCompleted(Result, Error);
            }
        }

        public void AbortAsync()
        {
            request?.Abort();
            request = null;
        }

        protected virtual void Reset()
        {
            IsDone = false;
            Progress = 0;
            Result = default;
            Error = null;
        }

        protected virtual UnityWebRequest CreateWebRequest(string url, IDictionary<string, string> headers = null)
        {
            var request = new UnityWebRequest(url)
            {
                timeout = TimeOut,
                downloadHandler = new DownloadHandlerBuffer(),
                method = UnityWebRequest.kHttpVerbGET
            };
            SetRequestHeader(request, headers);
            return request;
        }

        protected void SetRequestHeader(UnityWebRequest request, IDictionary<string, string> headers)
        {
            if (headers == null || headers.Count == 0)
            {
                return;
            }

            foreach (var header in headers)
            {
                request.SetRequestHeader(header.Key, header.Value);
            }
        }

        protected void InvokeOnProgressed(float progress)
        {
            OnProgressed?.Invoke(progress);
        }

        protected void InvokeOnCompleted(T result, Exception error)
        {
            OnCompleted?.Invoke(result, error);
        }

        protected abstract T ReadResult(UnityWebRequest request);
    }
}
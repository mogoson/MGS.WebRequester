/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Requester.cs
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

namespace MGS.WebRequest
{
    public abstract class Requester<T> : IRequester<T>
    {
        public string Url { set; get; }

        public int TimeOut { set; get; }

        public bool IsDone { protected set; get; }

        public T Result { protected set; get; }

        public Exception Error { protected set; get; }

        public event Action<float, T> OnProgress;
        public event Action<T, Exception> OnComplete;

        protected IDictionary<string, string> headers;
        protected UnityWebRequest request;
        protected bool isSSE;

        public Requester(string url, int timeOut, IDictionary<string, string> headers = null)
        {
            Url = url;
            TimeOut = timeOut;
            this.headers = headers;
            isSSE = CheckSSE(headers);
        }

        protected bool CheckSSE(IDictionary<string, string> headers)
        {
            if (headers == null || !headers.ContainsKey(Headers.KEY_ACCEPT))
            {
                return false;
            }
            return headers[Headers.KEY_ACCEPT] == Headers.VALUE_ACCEPT_TES;
        }

        protected virtual UnityWebRequest CreateWebRequest(string url, IDictionary<string, string> headers = null)
        {
            var request = new UnityWebRequest(url);
            SetRequestHeader(request, headers);
            request.timeout = TimeOut;
            request.downloadHandler = new DownloadHandlerBuffer();
            request.method = "GET";
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

        public IEnumerator ExecuteAsync()
        {
            IsDone = false;

            using (request = CreateWebRequest(Url, headers))
            {
                var operate = request.SendWebRequest();
                while (!operate.isDone)
                {
                    OnAsyncOperate(operate);
                    yield return null;
                }
                var success = operate.webRequest.result == UnityWebRequest.Result.Success;
                Result = success ? ReadResult(operate.webRequest) : default;
                Error = success ? default : new Exception(operate.webRequest.error);
                IsDone = true;
            }
            if (request != null)
            {
                request = null;
                OnComplete?.Invoke(Result, Error);
            }
        }

        protected virtual void OnAsyncOperate(UnityWebRequestAsyncOperation operation)
        {
            if (isSSE)
            {
                Result = ReadResult(operation.webRequest);
            }
            OnProgress?.Invoke(operation.progress, Result);
        }

        protected abstract T ReadResult(UnityWebRequest request);

        public void AbortAsync()
        {
            request?.Abort();
            request = null;
        }
    }
}
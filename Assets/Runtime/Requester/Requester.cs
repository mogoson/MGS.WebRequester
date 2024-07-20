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

        public event Action<float> OnProgress;
        public event Action<T, Exception> OnComplete;

        IDictionary<string, string> headers;
        protected UnityWebRequest request;

        public Requester(string url, int timeOut, IDictionary<string, string> headers = null)
        {
            Url = url;
            TimeOut = timeOut;
            this.headers = headers;
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

        public IEnumerator Send()
        {
            IsDone = false;

            using (request = CreateWebRequest(Url, headers))
            {
                var operate = request.SendWebRequest();
                while (!operate.isDone)
                {
                    OnProgress?.Invoke(operate.progress);
                    yield return null;
                }
                var success = request.result == UnityWebRequest.Result.Success;
                Result = success ? ReadResult(request) : default;
                Error = success ? default : new Exception(request.error);
                IsDone = true;
            }
            request = null;
            OnComplete?.Invoke(Result, Error);
        }

        protected abstract T ReadResult(UnityWebRequest request);

        public void Abort()
        {
            request?.Abort();
            request = null;
        }
    }
}
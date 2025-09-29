/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  RequestSample.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  09/28/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;

namespace MGS.Request.Sample
{
    public abstract class RequestSample<T> : MonoBehaviour
    {
        public string url = "https://github.com";
        public int timeOut = 30;

        protected virtual void Start()
        {
            var request = StartRequest();
            request.OnProgressed += OnProgressed;
            request.OnCompleted += OnCompleted;
        }

        protected abstract IWebRequest<T> StartRequest();

        protected void OnProgressed(float progress)
        {
            Debug.Log($"progress {progress}");
        }

        protected void OnCompleted(T result, Exception error)
        {
            if (error == null)
            {
                Debug.Log($"result {result}");
            }
            else
            {
                Debug.LogError($"error {error.Message}\r\n{error.StackTrace}");
            }
        }
    }
}
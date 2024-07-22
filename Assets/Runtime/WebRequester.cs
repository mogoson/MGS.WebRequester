/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  WebRequester.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/19
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace MGS.WebRequest
{
    public class WebRequester : MonoBehaviour, IWebRequester
    {
        public static IWebRequester Handler { get; }

        static WebRequester()
        {
            var handlerGo = new GameObject("WebRequester");
            DontDestroyOnLoad(handlerGo);
            Handler = handlerGo.AddComponent<WebRequester>();
        }

        public IRequester<string> FileRequest(string url, int timeOut, string path, IDictionary<string, string> headers = null)
        {
            var requester = new FileRequester(url, timeOut, path, headers);
            StartCoroutine(requester.ExecuteAsync());
            return requester;
        }

        public IRequester<string> GetRequest(string url, int timeOut, IDictionary<string, string> headers = null)
        {
            var requester = new GetRequester(url, timeOut, headers);
            StartCoroutine(requester.ExecuteAsync());
            return requester;
        }

        public IRequester<string> PostRequest(string url, byte[] data, int timeOut, IDictionary<string, string> headers = null)
        {
            var requester = new PostRequester(url, data, timeOut, headers);
            StartCoroutine(requester.ExecuteAsync());
            return requester;
        }
    }
}
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

        protected IDictionary<IRequester, Coroutine> requesters = new Dictionary<IRequester, Coroutine>();

        static WebRequester()
        {
            var handlerGo = new GameObject("WebRequester");
            DontDestroyOnLoad(handlerGo);
            Handler = handlerGo.AddComponent<WebRequester>();
        }

        public IRequester<string> FileRequestAsync(string url, int timeOut, string path, IDictionary<string, string> headers = null)
        {
            var requester = new FileRequester(url, timeOut, path, headers);
            requester.OnComplete += (r, e) => requesters.Remove(requester);

            var routine = StartCoroutine(requester.ExecuteAsync());
            requesters.Add(requester, routine);
            return requester;
        }

        public IRequester<string> GetRequestAsync(string url, int timeOut, IDictionary<string, string> headers = null)
        {
            var requester = new GetRequester(url, timeOut, headers);
            requester.OnComplete += (r, e) => requesters.Remove(requester);

            var routine = StartCoroutine(requester.ExecuteAsync());
            requesters.Add(requester, routine);
            return requester;
        }

        public IRequester<string> PostRequestAsync(string url, byte[] data, int timeOut, IDictionary<string, string> headers = null)
        {
            var requester = new PostRequester(url, data, timeOut, headers);
            requester.OnComplete += (r, e) => requesters.Remove(requester);

            var routine = StartCoroutine(requester.ExecuteAsync());
            requesters.Add(requester, routine);
            return requester;
        }

        public void AbortAsync(IRequester requester)
        {
            requester.AbortAsync();
            var routine = requesters[requester];
            if (routine != null)
            {
                StopCoroutine(routine);
            }
            requesters.Remove(requester);
        }

        public void AbortAll()
        {
            foreach (var requester in requesters.Keys)
            {
                AbortAsync(requester);
            }
        }
    }
}
/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  WebRequestHub.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/19
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using MGS.Operate;

namespace MGS.Request
{
    public class WebRequestHub : IWebRequestHub
    {
        public IAsyncOperateHub AsyncHub { protected set; get; }

        public WebRequestHub(IAsyncOperateHub asyncHub)
        {
            AsyncHub = asyncHub;
        }

        public IWebRequest<string> GetRequestAsync(string url, int timeOut, IDictionary<string, string> headers = null)
        {
            var request = new GetRequest(url, timeOut, headers);
            AsyncHub.Enqueue(request);
            return request;
        }

        public IWebRequest<string> PostRequestAsync(string url, int timeOut, byte[] data, IDictionary<string, string> headers = null)
        {
            var request = new PostRequest(url, data, timeOut, headers);
            AsyncHub.Enqueue(request);
            return request;
        }

        public IWebRequest<string> FileRequestAsync(string url, int timeOut, string path, IDictionary<string, string> headers = null)
        {
            var request = new FileRequest(url, timeOut, path, headers);
            AsyncHub.Enqueue(request);
            return request;
        }

        public IWebRequest<byte[]> DataRequestAsync(string url, int timeOut, IDictionary<string, string> headers = null)
        {
            var request = new DataRequest(url, timeOut, headers);
            AsyncHub.Enqueue(request);
            return request;
        }

        public void AbortAsync<T>(IWebRequest<T> request)
        {
            AsyncHub.Dequeue(request);
        }
    }
}
/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IWebRequestHub.cs
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
    public interface IWebRequestHub
    {
        IAsyncOperateHub AsyncHub { get; }

        IWebRequest<string> GetRequestAsync(string url, int timeOut, IDictionary<string, string> headers = null);

        IWebRequest<string> PostRequestAsync(string url, int timeOut, byte[] data, IDictionary<string, string> headers = null);

        IWebRequest<string> FileRequestAsync(string url, int timeOut, string path, IDictionary<string, string> headers = null);

        IWebRequest<byte[]> DataRequestAsync(string url, int timeOut, IDictionary<string, string> headers = null);

        void AbortAsync<T>(IWebRequest<T> request);
    }
}
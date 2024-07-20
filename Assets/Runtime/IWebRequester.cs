/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IWebRequester.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/19
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;

namespace MGS.WebRequest
{
    public interface IWebRequester
    {
        IRequester<string> GetRequest(string url, int timeOut, IDictionary<string, string> headers = null);

        IRequester<string> PostRequest(string url, byte[] data, int timeOut, IDictionary<string, string> headers = null);

        IRequester<string> FileRequest(string url, int timeOut, string path, IDictionary<string, string> headers = null);
    }
}
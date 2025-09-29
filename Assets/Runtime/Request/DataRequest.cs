/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  DataRequest.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2025/9/28
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine.Networking;

namespace MGS.Request
{
    public class DataRequest : WebRequest<byte[]>
    {
        public DataRequest(string url, int timeOut, IDictionary<string, string> headers = null)
            : base(url, timeOut, headers) { }

        protected override byte[] ReadResult(UnityWebRequest request)
        {
            return request.downloadHandler.data;
        }
    }
}
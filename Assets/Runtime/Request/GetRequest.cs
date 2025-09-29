/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GetRequest.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/19
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine.Networking;

namespace MGS.Request
{
    public class GetRequest : WebRequest<string>
    {
        public GetRequest(string url, int timeOut, IDictionary<string, string> headers = null)
            : base(url, timeOut, headers) { }

        protected override string ReadResult(UnityWebRequest request)
        {
            return request.downloadHandler.text;
        }
    }
}
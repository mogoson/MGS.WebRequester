/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GetRequester.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/19
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine.Networking;

namespace MGS.WebRequest
{
    public class GetRequester : Requester<string>
    {
        public GetRequester(string url, int timeOut, IDictionary<string, string> headers = null)
            : base(url, timeOut, headers)
        {

        }

        protected override string ReadResult(UnityWebRequest request)
        {
            return request.downloadHandler.text;
        }
    }
}
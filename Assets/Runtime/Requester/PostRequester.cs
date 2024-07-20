/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  PostRequester.cs
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
    public class PostRequester : Requester<string>
    {
        protected byte[] data;

        public PostRequester(string url, byte[] data, int timeOut, IDictionary<string, string> headers = null)
            : base(url, timeOut, headers)
        {
            this.data = data;
        }

        protected override UnityWebRequest CreateWebRequest(string url, IDictionary<string, string> headers = null)
        {
            var request = base.CreateWebRequest(url, headers);
            request.uploadHandler = new UploadHandlerRaw(data);
            request.method = "POST";
            return request;
        }

        protected override string ReadResult(UnityWebRequest request)
        {
            return request.downloadHandler.text;
        }
    }
}
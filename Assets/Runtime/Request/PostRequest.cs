/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  PostRequest.cs
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
    public class PostRequest : WebRequest<string>
    {
        protected byte[] data;

        public PostRequest(string url, byte[] data, int timeOut, IDictionary<string, string> headers = null)
            : base(url, timeOut, headers)
        {
            this.data = data;
        }

        protected override UnityWebRequest CreateWebRequest(string url, IDictionary<string, string> headers = null)
        {
            var request = base.CreateWebRequest(url, headers);
            request.uploadHandler = new UploadHandlerRaw(data);
            request.method = UnityWebRequest.kHttpVerbPOST;
            return request;
        }

        protected override string ReadResult(UnityWebRequest request)
        {
            return request.downloadHandler.text;
        }
    }
}
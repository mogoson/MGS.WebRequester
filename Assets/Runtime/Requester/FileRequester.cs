/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  FileRequester.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/19
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using System.IO;
using UnityEngine.Networking;

namespace MGS.WebRequest
{
    public class FileRequester : GetRequester
    {
        protected string path;

        public FileRequester(string url, int timeOut, string path, IDictionary<string, string> headers = null)
            : base(url, timeOut, headers)
        {
            this.path = path;
        }

        protected override string ReadResult(UnityWebRequest request)
        {
            File.WriteAllBytes(path, request.downloadHandler.data);
            return path;
        }
    }
}
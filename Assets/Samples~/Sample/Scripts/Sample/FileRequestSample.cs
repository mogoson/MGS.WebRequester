/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  FileRequestSample.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  09/28/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using System.IO;
using UnityEngine;

namespace MGS.Request.Sample
{
    public class FileRequestSample : RequestSample<string>
    {
        protected override IWebRequest<string> StartRequest()
        {
            var filePath = $"{Application.persistentDataPath}/{Path.GetFileName(url)}";
            return Global.RequestHub.FileRequestAsync(url, timeOut, filePath);
        }
    }
}
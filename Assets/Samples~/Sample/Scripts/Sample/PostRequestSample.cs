/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  PostRequestSample.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  09/28/2025
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Request.Sample
{
    public class PostRequestSample : RequestSample<string>
    {
        protected override IWebRequest<string> StartRequest()
        {
            var data = new byte[] { 0 };
            return Global.RequestHub.PostRequestAsync(url, timeOut, data);
        }
    }
}
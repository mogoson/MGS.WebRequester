/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  GetRequestSample.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  09/28/2025
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Request.Sample
{
    public class GetRequestSample : RequestSample<string>
    {
        protected override IWebRequest<string> StartRequest()
        {
            return Global.RequestHub.GetRequestAsync(url, timeOut);
        }
    }
}
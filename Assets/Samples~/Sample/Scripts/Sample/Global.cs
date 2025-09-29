/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Global.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  09/28/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Operate;

namespace MGS.Request.Sample
{
    public sealed class Global
    {
        public static IWebRequestHub RequestHub { get; }

        static Global()
        {
            var asyncHub = new AsyncOperateHub();       //Execute immediately
            //var asyncHub = new AsyncOperateHubPro();  //Concurrent scheduling
            RequestHub = new WebRequestHub(asyncHub);
        }
    }
}
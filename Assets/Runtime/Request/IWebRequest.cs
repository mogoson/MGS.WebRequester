/*************************************************************************
 *  Copyright © 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IWebRequest.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/19
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Operate;

namespace MGS.Request
{
    public interface IWebRequest<T> : IAsyncOperate<T>
    {
        string Url { set; get; }

        int TimeOut { set; get; }
    }
}
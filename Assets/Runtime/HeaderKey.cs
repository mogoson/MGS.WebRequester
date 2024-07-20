/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  HeaderKey.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/19
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.WebRequest
{
    public sealed class HeaderKey
    {
        /// <summary>
        /// Content-Type
        /// example: "application/json"
        /// </summary>
        public const string CONTENT_TYPE = "Content-Type";

        /// <summary>
        /// Authorization
        /// example: "Bearer {ApiKey}"
        /// </summary>
        public const string AUTHORIZATION = "Authorization";

        /// <summary>
        /// Range
        /// example: "bytes=0-100"
        /// </summary>
        public const string RANGE = "Range";
    }
}
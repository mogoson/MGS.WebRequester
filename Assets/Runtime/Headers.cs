/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Headers.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/19
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.WebRequest
{
    public sealed class Headers
    {
        public const string KEY_CONTENT_TYPE = "Content-Type";
        public const string VALUE_CONTENT_JSON = "application/json";

        public const string KEY_AUTHORIZATION = "Authorization";
        public const string VALUE_AUTHORIZATION_BEARER = "Bearer {0}";

        public const string KEY_ACCEPT = "Accept";
        public const string VALUE_ACCEPT_TES = "text/event-stream";

        public const string KEY_RANGE = "Range";
        public const string VALUE_RANGE = "bytes={0}-{1}";
    }
}
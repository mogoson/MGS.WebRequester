/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  IRequester.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/19
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections;

namespace MGS.WebRequest
{
    public interface IRequester<T>
    {
        string Url { set; get; }

        int TimeOut { set; get; }

        bool isDone { get; }

        T Result { get; }

        Exception Error { get; }

        event Action<float> OnProgress;

        event Action<T, Exception> OnComplete;

        IEnumerator Send();

        void Abort();
    }
}
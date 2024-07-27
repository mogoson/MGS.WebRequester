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
    public interface IRequester
    {
        string Url { set; get; }

        int TimeOut { set; get; }

        bool IsDone { get; }

        Exception Error { get; }

        IEnumerator ExecuteAsync();

        void AbortAsync();
    }

    public interface IRequester<T> : IRequester
    {
        T Result { get; }

        event Action<float, T> OnProgress;

        event Action<T, Exception> OnComplete;
    }
}
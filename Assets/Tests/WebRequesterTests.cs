/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  WebRequesterTests.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/19
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections;
using MGS.WebRequest;
using UnityEngine;
using UnityEngine.TestTools;

public class WebRequesterTests
{
    [UnityTest]
    public IEnumerator GetRequestTest()
    {
        var url = "https://github.com";
        var requester = WebRequester.Handler.GetRequestAsync(url, 120);
        requester.OnProgress += Requester_OnProgress;
        requester.OnComplete += Requester_OnComplete;
        while (!requester.IsDone)
        {
            yield return null;
        }
    }

    [UnityTest]
    public IEnumerator PostRequestTest()
    {
        var url = "https://github.com";
        var requester = WebRequester.Handler.PostRequestAsync(url, new byte[0], 120);
        requester.OnProgress += Requester_OnProgress;
        requester.OnComplete += Requester_OnComplete;
        while (!requester.IsDone)
        {
            yield return null;
        }
    }

    [UnityTest]
    public IEnumerator FileRequestTest()
    {
        var url = "https://github.com";
        var path = $"{Application.persistentDataPath}/Tests/github.html";
        var requester = WebRequester.Handler.FileRequestAsync(url, 120, path);
        requester.OnProgress += Requester_OnProgress;
        requester.OnComplete += Requester_OnComplete;
        while (!requester.IsDone)
        {
            yield return null;
        }
    }

    private void Requester_OnComplete(string result, Exception error)
    {
        if (error == null)
        {
            Debug.Log($"result: {result}");
        }
        else
        {
            Debug.LogError($"error: {error.Message}");
        }
    }

    private void Requester_OnProgress(float progress, string result)
    {
        Debug.Log($"progress: {progress} result: {result}");
    }
}
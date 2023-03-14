using System;
using System.Collections; // IEnumerator
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking; // API Requests

public class CoroutineWithData<T>
{
    private IEnumerator _target;
    public T result;
    public Coroutine Coroutine { get; private set; }

    public CoroutineWithData(MonoBehaviour owner_, IEnumerator target_)
    {
        _target = target_;
        Coroutine = owner_.StartCoroutine(Run());
    }

    private IEnumerator Run()
    {
        while(_target.MoveNext())
        {
            result = (T)_target.Current;
            yield return result;
        }
    }
}

/* Class represents server information such as the API base uri */
public class Server 
{
    public string uri  { get; set; }
    public static string LoginUri = "/api/token/"; 

    public Server(){}

    public void setUri(string uri) {
        this.uri = uri;
    }

    public string getLoginUri() {return LoginUri;}
}

/// <summary>
///  This class controls the communication with the backend server using http requests.
/// </summary>
public class BackEndController : MonoBehaviour
{
    public Server server { get; set; }

    public BackEndController()
    {
        this.server = new Server();
    }

    /* Handles responses from UnityWebRequest calls using a DownloadHandler */
    public IEnumerator DLHResponseHandler(UnityWebRequest www)
    {
        www.downloadHandler = new DownloadHandlerBuffer();
        yield return www.SendWebRequest();
        string response = "";
        if (www.result != UnityWebRequest.Result.Success) {
            response = www.error;
            Debug.Log("Error: UnityWebRequestError for " + www + ": " + response);
            yield break;  // stop running method
        }
        else {
            response = www.downloadHandler.text;
        }
        yield return response;
    }
}
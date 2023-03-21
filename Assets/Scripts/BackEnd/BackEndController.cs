using System;
using System.Collections; // IEnumerator
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking; // API Requests

// public class CoroutineWithData<T>
// {
//     private IEnumerator _target;
//     public T result;
//     public Coroutine Coroutine { get; private set; }

//     public CoroutineWithData(MonoBehaviour owner_, IEnumerator target_)
//     {
//         _target = target_;
//         Coroutine = owner_.StartCoroutine(Run());
//     }

//     private IEnumerator Run()
//     {
//         while(_target.MoveNext())
//         {
//             result = (T)_target.Current;
//             yield return result;
//         }
//     }
// }

/// <summary>
///  This class represents server information such as the API uri's.
/// </summary>
public class Server 
{
    public string uri  { get; set; }
    public static string LoginUri = "/api/token/"; 
    public static string ViolationUri = "/api/violation";

    public Server(){}

    public void setUri(string uri) {
        this.uri = uri;
    }

    public string getLoginUri() {
        return LoginUri;
    }

    public string getFullLoginUri() {
        return uri + LoginUri;
    }
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

    // /* Retrieves responses from UnityWebRequest calls using a DownloadHandler and callbacks */
    // public IEnumerator DLHResponseHandler(UnityWebRequest www, System.Action<string> callback)
    // {
    //     www.downloadHandler = new DownloadHandlerBuffer();
    //     string response = "";
    //     if (www.result != UnityWebRequest.Result.Success) {
    //         response = www.error;
    //         Debug.Log("Error: UnityWebRequestError for " + www + ": " + response);
    //         callback(null);
    //         yield break;  // stop running method
    //     }
    //     else {
    //         response = www.downloadHandler.text;
    //     }
    //     callback(response);
    // }
    
}
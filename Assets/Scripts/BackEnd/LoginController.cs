using System;
using System.Collections; // IEnumerator
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking; // API Requests
using Newtonsoft.Json.Linq; // Json Deserializing

/// <summary>
///  This class controls login communication with the backend server.
/// </summary>
public class LoginController : BackEndController
{
    public LoginController() : base()
    {
    }

    /* Sends POST request to server to login and receives a new refresh string if succesful */
    public IEnumerator RequestLogin(string username, string password) {
        string uri = base.server.getLoginUri();

        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);
        var request = UnityWebRequest.Post(uri, form);
        CoroutineWithData<string> cr = new CoroutineWithData<string>(this, base.DLHResponseHandler(request));
        yield return cr.Coroutine;

        JsonHandler(cr.result);
    }

    /* Parses json request from API call "create user" to retrieve the refresh code and add it to the User class instance */
    public void JsonHandler(string jsonString) {
        JObject jobject = JObject.Parse(jsonString);
        JToken refreshCode = jobject["refresh"];
        JToken accessCode = jobject["access"];
        Debug.Log(refreshCode.ToString());
        Debug.Log(accessCode.ToString());
        //TODO save codes refreshCode.ToString()
    }

}
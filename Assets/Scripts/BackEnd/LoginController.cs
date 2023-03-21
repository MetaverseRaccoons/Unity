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
    {}

    /* Sends a 'login' request to the server */
    public IEnumerator RequestLogin(string username, string password)
    {
        string uri = base.server.getFullLoginUri();
        Debug.Log(uri);

        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        using (UnityWebRequest www = UnityWebRequest.Post(uri, form))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success) {
                Debug.Log(www.error);
            } else {
                Debug.Log("Form upload complete!");
                JsonHandler(www.downloadHandler.text);
            }
        }
    }

    /* Retrieves refresh and access codes after 'login' API call and adds them to the LoginControllerObj in the form of a Credentials instance. */
    public void JsonHandler(string jsonString) {
        JObject jobject = JObject.Parse(jsonString);
        JToken refreshCode = jobject["refresh"];
        JToken accessCode = jobject["access"];
        LoginControllerObj.AddComponent<Credentials>(refreshCode, accessCode);
    }
}
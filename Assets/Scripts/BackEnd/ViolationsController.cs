using System;
using System.Collections; // IEnumerator
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; // API Requests
using Newtonsoft.Json.Linq; // Json Deserializing


/// <summary>
///  This class controls violations communication with the backend server.
/// </summary>
public class ViolationsController : BackEndController
{
    public ViolationsController() : base()
    {}

    /* Sends a 'add violation' request to the server */
    public IEnumerator RequestAddViolation(string type, string severity, string description)
    {
        string uri = base.server.getViolationUri();

        // retrieve encoded access string and decode it
        GameObject gco = GameObject.Find("GameControllerObj");  // GameControllerObj should be in DontDestroyOnLoad
        GameController gc = (GameController) gco.GetComponent(typeof(GameController));
        string access_encoded = PlayerPrefs.GetString("access");
        string access = gc.ec.DecryptStringFromBytes_Aes(Convert.FromBase64String(access_encoded), gc.aes.Key, gc.aes.IV);

        WWWForm form = new WWWForm();
        form.AddField("type", type);
        form.AddField("severity", severity);
        form.AddField("description", description);

        using (UnityWebRequest www = UnityWebRequest.Post(uri, form))
        {
            www.SetRequestHeader("Authorization", "Bearer " + access);
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success) {
                Debug.Log(www.error);
            } else {
                JsonHandler(www.downloadHandler.text);
            }
        }
    }

    /* Logs the server response (`jsonString`) from an API call */
    public void JsonHandler(string jsonString) {
        JObject jobject = JObject.Parse(jsonString);
        JToken msg = jobject["message"];
        Debug.Log("Server response: " + msg.ToString());
    }
}
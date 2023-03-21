using System;
using System.Collections; // IEnumerator
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; // API Requests
using Newtonsoft.Json.Linq; // Json Deserializing

public class ViolationsScript : MonoBehaviour
{
    public Button button;
    public GameObject ViolationsControllerObj;  // ViolationsController script needs to be attached to a GameObject

    public void AddViolation()
    {
        button.Select();
        ViolationsController vc = ViolationsControllerObj.AddComponent<ViolationsController>();
        StartCoroutine(vc.RequestAddViolation("speeding", "0.75", "Speeding in a 30km/h zone"));
    }
}


/// <summary>
///  This class controls login communication with the backend server.
/// </summary>
public class ViolationsController : BackEndController
{
    public ViolationsController() : base()
    {}

    /* Sends a 'add violation' request to the server */
    public IEnumerator RequestAddViolation(string type, string severity, string description)
    {
        string uri = base.server.getFullLoginUri();

        WWWForm form = new WWWForm();
        form.AddField("type", type);
        form.AddField("severity", severity);
        form.AddField("description", description);

        using (UnityWebRequest www = UnityWebRequest.Post(uri, form))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success) {
                Debug.Log(www.error);
            } else {
                JsonHandler(www.downloadHandler.text);
            }
        }
    }

    /* Logs the server response from the 'add violation' API call */
    public void JsonHandler(string jsonString) {
        JObject jobject = JObject.Parse(jsonString);
        JToken msg = jobject["message"];
        Debug.Log("Server response: " + msg.ToString());
    }
}
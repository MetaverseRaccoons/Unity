using System;
using System.Collections; // IEnumerator
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; // API Requests
using Newtonsoft.Json.Linq; // Json Deserializing

/// <summary>
///  This class controls profile communication with the backend server.
/// </summary>
public class ProfileController : BackEndController
{
    public ProfileController() : base()
    {}

    /* Sends a 'request user information' request to the server */
    public IEnumerator RequestProfileInformation()
    {
        string uri = base.server.getProfileUri();

        // retrieve encoded access string and decode it
        GameObject gco = GameObject.Find("GameControllerObj");  // GameControllerObj should be in DontDestroyOnLoad
        GameController gc = (GameController) gco.GetComponent(typeof(GameController));
        string access_encoded = gc.user.access;
        string access = gc.ec.DecryptStringFromBytes_Aes(Convert.FromBase64String(access_encoded), gc.aes.Key, gc.aes.IV);

        using (UnityWebRequest www = UnityWebRequest.Get(uri))
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
        // parse json string
        JObject jobject = JObject.Parse(jsonString);
        JToken username = jobject["username"];
        JToken email = jobject["email"];
        JToken is_learner = jobject["is_learner"];
        JToken is_instructor = jobject["is_instructor"];
        JToken has_drivers_license = jobject["has_drivers_license"];
        JToken is_shareable = jobject["is_shareable"];
        JToken km_driven = jobject["km_driven"];
        JToken minutes_driven = jobject["minutes_driven"];

        Debug.Log(has_drivers_license.ToString());

        // save user info to User class
        GameObject gco = GameObject.Find("GameControllerObj");  // GameControllerObj should be in DontDestroyOnLoad
        GameController gc = (GameController) gco.GetComponent(typeof(GameController));

        gc.user.username = username.ToString();
        gc.user.email = email.ToString();
        gc.user.is_learner = is_learner.ToString();
        gc.user.is_instructor = is_instructor.ToString();
        gc.user.has_drivers_license = has_drivers_license.ToString();
        gc.user.is_shareable = is_shareable.ToString();
        gc.user.km_driven = km_driven.ToString();
        gc.user.minutes_driven = minutes_driven.ToString();

        Debug.Log("User profile information successfully saved in User class.");
    }
}
using System;
using System.Collections; // IEnumerator
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking; // API Requests
// using UnityEngine.CoreModule; // PlayerPrefs
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
        string uri = base.server.getLoginUri();

        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        using (UnityWebRequest www = UnityWebRequest.Post(uri, form))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success) {
                Debug.Log(www.error);
                GameObject gco = GameObject.Find("GameControllerObj");  // GameControllerObj should be in DontDestroyOnLoad
                GameController gc = (GameController) gco.GetComponent(typeof(GameController));
                
                // find keyboard script, to pass API response messages
                GameObject keyboardObject = GameObject.Find("OnScreenKeyboard");
                KeyboardScript keyboard = (KeyboardScript) keyboardObject.GetComponent(typeof(KeyboardScript));

                if (www.error == "Cannot connect to destination host") {    
                    keyboard.setMsg("Cannot connect to destination host", false);
                }
                else if (www.error == "HTTP/1.1 401 Unauthorized") {
                    keyboard.setMsg("Wrong username or password", false);
                }
            } else {
                JsonHandler(www.downloadHandler.text);
            }
        }
    }

    /* Retrieves refresh and access codes from `jsonString`, encrypts them and saves them in PlayerPrefs. */
    public void JsonHandler(string jsonString) {
        JObject jobject = JObject.Parse(jsonString);
        JToken refreshCode = jobject["refresh"];
        JToken accessCode = jobject["access"];

        // encode access and refresh string
        GameObject gco = GameObject.Find("GameControllerObj");  // GameControllerObj should be in DontDestroyOnLoad
        GameController gc = (GameController) gco.GetComponent(typeof(GameController));
        byte[] refresh_encoded = gc.ec.EncryptStringToBytes_Aes(refreshCode.ToString(), gc.aes.Key, gc.aes.IV);
        byte[] access_encoded = gc.ec.EncryptStringToBytes_Aes(accessCode.ToString(), gc.aes.Key, gc.aes.IV);

        // save access and refresh to User class
        gc.user.refresh = Convert.ToBase64String(refresh_encoded);
        gc.user.access = Convert.ToBase64String(access_encoded);
        Debug.Log("User credentials successfully saved in PlayerPrefs.");

        LoadProfileScene();
    }

    public void LoadProfileScene() {
        GameObject gco = GameObject.Find("GameControllerObj");  // GameControllerObj should be in DontDestroyOnLoad
        GameController gc = (GameController) gco.GetComponent(typeof(GameController));

        gc.login = true;
        StartCoroutine(gc.pc.RequestProfileInformation());
        gc.sl.LoadScene("menu_profile");
    }
}
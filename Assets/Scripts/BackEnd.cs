using System.Collections; // IEnumerator
using System.Collections.Generic;
using System;
using System.Reflection; // ChangeType()
using UnityEngine;
using UnityEngine.Networking; // API Requests
using Newtonsoft.Json.Linq; // Json Deserializing

/* TODO: there is a weird bug where the user is created twice, with a 500 internal server error as 2nd because the username is unique. */


/* Class represents data necessary to create users in database */
public class User
{
    public string username { get; set; }
    public string password1 { get; set; }
    public string password2 { get; set; }
    public string email { get; set; }
    public string national_registration_number { get; set; }
    public bool is_learner { get; set; }
    public bool is_instructor { get; set; }
    public bool has_drivers_license { get; set; }
    public bool is_shareable { get; set; }
    public string refresh { get; set; }
    public string access { get; set; }
    
    public User(string username, string password1, string password2, string email, string national_registration_number, bool is_learner, bool is_instructor, bool has_drivers_license, bool is_shareable, string refresh = null, string access = null)
    {
        this.username = username;
        this.password1 = password1;
        this.password2 = password2;
        this.email = email;
        this.national_registration_number = national_registration_number;
        this.is_learner = is_learner;
        this.is_instructor = is_instructor;
        this.has_drivers_license = has_drivers_license;
        this.is_shareable = is_shareable;
        this.refresh = refresh;
        this.access = access;
    }
}

/* Class represents server information such as the API base uri */
static public class Server 
{
    public static string uri = "http://127.0.0.1:8000";
    public static User dries = new User(
            "j1",
            "driespaswoord1",
            "driespaswoord1",
            "dries.vanspauwen@gmail.com",
            "00.00.00-000.00",
            false,
            false,
            false,
            false
        );
}

public class DataTest : MonoBehaviour
{
    /* Start is called before the first frame update */
    private void Start()
    {
        RequestCreateUser(Server.dries);
    }

    /* Sends POST request to server to create user */
    private void RequestCreateUser(User user)
    {
        string uri = Server.uri + "/api/user/";
        WWWForm form = new WWWForm();

        // add all properties of 'user' to 'form' with the name and value of each property as strings
        foreach(PropertyInfo prop in typeof(User).GetProperties())
        {
            // API doesn't expect a refresh and access code
            if (prop.Name != "refresh" && prop.Name != "access") {
                object value = prop.GetValue(user, null);
                string valueStr = (string)Convert.ChangeType(value, typeof(string));
                form.AddField(prop.Name, valueStr);
            }
        }
        try
        {
            var request = UnityWebRequest.Post(uri, form);
            StartCoroutine(DLHResponseHandler(request, "CreateUser", user));
        }
        catch (Exception e) { Debug.Log("COROUTINE ERROR : " + e.Message); }
    }

    /* Sends POST request to server to delete a user based on the access string of that user */
    private void RequestDeleteUser(string access) {
        string uri = Server.uri + "/api/user/delete/";
        if (access != null) {
            try
            {
                var request = UnityWebRequest.Post(uri, new WWWForm());
                request.SetRequestHeader("Authorization", "Bearer " + access);
                StartCoroutine(DLHResponseHandler(request, "DeleteUser"));
            }
            catch (Exception e) { Debug.Log("COROUTINE ERROR : " + e.Message); }
        }
    }

    /* Sends POST request to server to login and receives a new refresh string if succesful */
    private void RequestLogin(string username, string password, User user) {
        string uri = Server.uri + "/api/token/";

        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        var request = UnityWebRequest.Post(uri, form);
        request.SetRequestHeader("Authorization", "Bearer " + user.access);
        StartCoroutine(DLHResponseHandler(request, "Login", user));
    }
    
    /* Sends POST request to server to get user data from the user with username 'username' and access code 'access' */
    private void RequestGetUser(string username, string access)
    {
        string uri = Server.uri + "/api/user/" + username + "/";
        if (access != null) {
            try
            {
                var request = UnityWebRequest.Get(uri);
                request.SetRequestHeader("Authorization", "Bearer " + access);
                StartCoroutine(DLHResponseHandler(request, "GetUser"));
            }
            catch (Exception e) { Debug.Log("COROUTINE ERROR : " + e.Message); }
        }
    }

    /* Handles responses from UnityWebRequest calls using a DownloadHandler */
    private IEnumerator DLHResponseHandler(UnityWebRequest www, string apiCall, User user = null)
    {
        www.downloadHandler = new DownloadHandlerBuffer();
        yield return www.SendWebRequest();
        string response = "";
        if (www.result != UnityWebRequest.Result.Success) {
            response = www.error;
            Debug.Log("UNITYWEBREQUEST ERROR FOR " + apiCall + ": " + response);
            yield break;  // stop running method
        }
        else {
            Debug.Log("ELSE: " + apiCall);
            response = www.downloadHandler.text;
        }

        // switch expression to define what to do next per call
        switch(apiCall)
        {
            case "CreateUser":
                Debug.Log("Case: CreateUser");
                JsonHandlerCreateUser(response, user);
                break;
            case "GetUser":
                Debug.Log("Case: GetUser");
                // Debug.Log(response);
                break;
            case "DeleteUser":
                Debug.Log("Case: DeleteUser");
                break;
            case "Login":
                Debug.Log("Case: Login");
                JsonHandlerLogin(response, user);
                break;
        }
    }

    /* Parses json request from API call "create user" to retrieve refresh and access codes, and adds these to the User class instance */
    private void JsonHandlerCreateUser(string jsonString, User user) {
        if (user == null) {
            Debug.Log("User passed cannot be null");
        }
        JObject jobject = JObject.Parse(jsonString);
        JToken refreshCode = jobject["refresh"];
        JToken accessCode = jobject["access"];
        user.refresh = refreshCode.ToString();
        user.access = accessCode.ToString();
    }

    /* Parses json request from API call "create user" to retrieve the refresh code and add it to the User class instance */
    private void JsonHandlerLogin(string jsonString, User user) {
        if (user == null) {
            Debug.Log("User passed cannot be null");
        }
        JObject jobject = JObject.Parse(jsonString);
        JToken refreshCode = jobject["refresh"];
        user.refresh = refreshCode.ToString();
        Debug.Log("jsonhandler login: " + user.refresh);
    }

    public void onClickDeleteUser() {
        Debug.Log("onclick method: " + Server.dries.access);
        RequestDeleteUser(Server.dries.access);
    }

    public void onClickLogin() {
        RequestLogin(Server.dries.username, Server.dries.password1, Server.dries);
    }

    /* Update is called once per frame */
    void Update()
    {
    }
}
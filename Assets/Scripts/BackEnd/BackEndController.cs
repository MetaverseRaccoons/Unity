using System;
using System.Collections; // IEnumerator
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking; // API Requests

/// <summary>
///  This class represents server information such as the API uri's.
/// </summary>
public class Server 
{
    public string uri  { get; set; }
    public static string LoginUri = "/api/token/"; 
    public static string ViolationUri = "/api/violation/";
    public static string KilometersUri = "/api/km_driven/";
    public static string MinutesUri = "/api/minutes_driven/";
    public static string ProfileUri = "/api/user/";

    public Server()
    {
        this.uri = "http://127.0.0.1:8000";
    }

    public void setUri(string uri) {
        this.uri = uri;
    }

    public string getLoginUri() {
        return uri + LoginUri;
    }

    public string getViolationUri() {
        return uri + ViolationUri;
    }

    public string getKilometersUri() {
        return uri + KilometersUri;
    }

    public string getMinutesUri() {
        return uri + MinutesUri;
    }

    public string getProfileUri() {
        return uri + ProfileUri;
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

}
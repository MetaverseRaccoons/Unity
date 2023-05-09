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
public class User
{
    public string refresh;
    public string access;
    public string username;
    public string email;
    public string is_learner;
    public string is_instructor;
    public string has_drivers_license;
    public string is_shareable;
    public string km_driven;
    public string minutes_driven;

    public User(){}
    
}
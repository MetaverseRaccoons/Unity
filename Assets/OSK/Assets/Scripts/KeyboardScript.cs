using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; // API Requests
using System.Reflection; // ChangeType()
using Newtonsoft.Json.Linq; // Json Deserializing

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

public class KeyboardScript : MonoBehaviour
{
    public InputField UsernameTextField, PasswordTextField, TextField;
    public Button UsernameButton, PasswordButton; // wrapper buttons because onClick functionality doesn't work well with InputFields
    public bool FieldSelector = true;  // true: username ; false: password
    public GameObject EngLayoutSml, EngLayoutBig, SymbLayout;
    public GameObject LoginControllerObj;  // MonoBehaviour LoginController script needs to be attached to a GameObject

    /* Puts string 'alphabet' in the selected TextField object */
    public void alphabetFunction(string alphabet)
    {
        TextField = FieldSelector ? UsernameTextField : PasswordTextField;
        TextField.text=TextField.text + alphabet;
    }

    /* Removes last character in the selected TextField object */
    public void BackSpace()
    {
        TextField = FieldSelector ? UsernameTextField : PasswordTextField;
        if(TextField.text.Length>0) TextField.text= TextField.text.Remove(TextField.text.Length-1);
    }

    /* Puts enter character in the selected TextField object */
    public void Enter()
    {
        CloseAllLayouts();
        ChangeSelection(FieldSelector ? UsernameButton : PasswordButton);
    }

    /* Closes all three keyboard layouts */
    public void CloseAllLayouts()
    {
        EngLayoutSml.SetActive(false);
        EngLayoutBig.SetActive(false);
        SymbLayout.SetActive(false);
    }

    /* Shows the selected layout by setting it to active */
    public void ShowLayout(GameObject SetLayout)
    {
        CloseAllLayouts();
        SetLayout.SetActive(true);
    }

    /* Changes the selected key in the keyboard to 'button' */
    public void ChangeSelection(Button button)
    {
        button.Select();
    }

    /* Puts FieldSector to username value and displays the keyboard layout */ 
    public void ActivateUsername()
    {
        FieldSelector = true;
        CloseAllLayouts();
        EngLayoutSml.SetActive(true);
    }

    /* Puts FieldSector to password value and displays the keyboard layout */  
    public void ActivatePassword()
    {
        FieldSelector = false;
        CloseAllLayouts();
        EngLayoutSml.SetActive(true);
    }


    /* Retrieves input from both textfields and calls Login function */
    public void AttemptLogin()
    {
        string username = UsernameTextField.text.ToString();
        string password = PasswordTextField.text.ToString();
        LoginController lc = LoginControllerObj.AddComponent<LoginController>();
        lc.server.setUri("http://127.0.0.1:8000");
        StartCoroutine(lc.RequestLogin("user1", "passwordDries1"));
    }

    public IEnumerator RequestCreateUser()
    // Needs to be run with a Coroutine!
    {
        User user = new User(
            "user1",
            "passwordDries1",
            "passwordDries1",
            "dries.vanspauwen@gmail.com",
            "00.00.00-000.00",
            false,
            false,
            false,
            false
        );

        string uri = "http://127.0.0.1:8000/api/user/";
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
        using (UnityWebRequest www = UnityWebRequest.Post(uri, form))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success) {
                Debug.Log(www.error);
            } else {
                Debug.Log("Form upload complete!");
            }
        }
    }

}

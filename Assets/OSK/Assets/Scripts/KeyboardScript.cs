using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; // API Requests
using System.Reflection; // ChangeType()
using Newtonsoft.Json.Linq; // Json Deserializing
using TMPro; // textmeshpro label

/// <summary>
///  This class controls the Unity keyboard, input fields and login button functionality.
/// </summary>
public class KeyboardScript : MonoBehaviour
{
    public InputField UsernameTextField, PasswordTextField, TextField;
    public Button UsernameButton, PasswordButton; // wrapper buttons because onClick functionality doesn't work well with InputFields
    public bool FieldSelector = true;  // true: username ; false: password
    public bool shifted = false;
    public GameObject EngLayoutSml, EngLayoutBig, SymbLayout;
    public GameObject LoginControllerObj;  // MonoBehaviour LoginController script needs to be attached to a GameObject
    public Button ShiftSmall;
    public TMP_Text Msg;
    

    /* Puts string 'alphabet' in the selected TextField object */
    public void alphabetFunction(string alphabet)
    {
        TextField = FieldSelector ? UsernameTextField : PasswordTextField;
        TextField.text=TextField.text + alphabet;
        if (shifted == true) {
            shifted = false;
            CloseAllLayouts();
            EngLayoutSml.SetActive(true);
            ChangeSelection(ShiftSmall);
        }
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
    }

    /*  */
    public void Shift()
    {
        shifted = true;
    }

    /* Closes all three keyboard layouts */
    public void CloseAllLayouts()
    {
        EngLayoutSml.SetActive(false);
        EngLayoutBig.SetActive(false);
        SymbLayout.SetActive(false);
        ChangeSelection(FieldSelector ? UsernameButton : PasswordButton);
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
        PasswordTextField.contentType = InputField.ContentType.Password;
        FieldSelector = false;
        CloseAllLayouts();
        EngLayoutSml.SetActive(true);
    }


    /* Retrieves input from both textfields and calls Login function */
    public void AttemptLogin()
    {
        string username = UsernameTextField.text.ToString();
        string password = PasswordTextField.text.ToString();
        
        GameObject gco = GameObject.Find("GameControllerObj");  // GameControllerObj should be in DontDestroyOnLoad
        GameController gc = (GameController) gco.GetComponent(typeof(GameController));
        StartCoroutine(gc.lc.RequestLogin(username, password));
    }

    public void setMsg(string msg, bool success=true) {
        if (success) {
            Msg.color = new Color(0, 1, 0, 1); // (R, G, B, Alpha)
        }
        else {
            Msg.color = new Color(1, 0, 0, 1); // (R, G, B, Alpha)
        }
        this.Msg.text = msg;
    }

}

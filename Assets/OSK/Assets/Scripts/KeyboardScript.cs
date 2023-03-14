using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        lc.RequestLogin(username, password);
        
    }

}

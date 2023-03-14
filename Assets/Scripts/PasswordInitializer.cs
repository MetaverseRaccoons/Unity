using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordInitializer : MonoBehaviour
{

    public InputField PasswordField;

    // Start is called before the first frame update
    void Start()
    {
        PasswordField.contentType = InputField.ContentType.Password;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

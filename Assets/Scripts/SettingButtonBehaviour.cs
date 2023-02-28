using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Luminosity.IO;
using TMPro;

public class SettingButtonBehaviour : MonoBehaviour
{
    public string ButtonAction;

    public void Start()
    {
        InputAction inputAction = InputManager.GetAction("CustomControls", ButtonAction);
        GetComponentInChildren<TextMeshProUGUI>().text = inputAction.Bindings[0].Positive.ToString();
        Debug.Log("Changed button text.");
    }

    public void changeKey()
    {
        ScanSettings settings = new ScanSettings
        {
            ScanFlags = ScanFlags.Key,
            // If the player presses this key the scan will be canceled.
            CancelScanKey = KeyCode.Escape,
            // If the player doesn't press any key within the specified number
            // of seconds the scan will be canceled.
            Timeout = 10
        };

        Debug.Log("Scanning");

        InputManager.StartInputScan(settings, result =>
        {
            // The handle should return "true" if the key is accepted or "false" if the key is rejected.
            // If the key is rejected the scan will continue until a key is accepted or until the timeout expires.

            InputAction inputAction = InputManager.GetAction("CustomControls", ButtonAction);
            inputAction.Bindings[0].Positive = result.Key;
            Debug.Log("Scan complete: " + result.Key.ToString() + ".");
            InputManager.Save();
            Debug.Log("Saved.");
            GetComponentInChildren<TextMeshProUGUI>().text = result.Key.ToString();
            Debug.Log("Changed button text.");
            return true;
        });
    }

    // public void changeJoystick()
    // {
    //     ScanSettings settings = new ScanSettings
    //     {
    //         ScanFlags = ScanFlags.JoystickButton | ScanFlags.JoystickAxis,
    //         // If the player presses this key the scan will be canceled.
    //         CancelScanKey = KeyCode.Escape,
    //         // If the player doesn't press any key within the specified number
    //         // of seconds the scan will be canceled.
    //         Timeout = 10
    //     };

    //     // You can replace the lambda function with a member function if you want.
    //     InputManager.StartInputScan(settings, result =>
    //     {
    //         // The handle should return "true" if the button is accepted or "false" if the button is rejected.
    //         // If the button is rejected the scan will continue until a button is accepted or until the timeout expires.

    //         if(result.ScanFlags == ScanFlags.JoystickButton)
    //         {
    //             if((int)result.Key < (int)KeyCode.JoystickButton0 || (int)result.Key > (int)KeyCode.JoystickButton19)
    //                 return false;

    //             InputAction inputAction = InputManager.GetAction("MyControlScheme", "MyAction");
    //             inputAction.Bindings[0].Type = InputType.Button;
    //             inputAction.Bindings[0].Positive = result.Key;
    //         }
    //         else
    //         {
    //             InputAction inputAction = InputManager.GetAction("MyControlScheme", "MyAction");
    //             inputAction.Bindings[0].Type = InputType.AnalogButton;
    //             inputAction.Bindings[0].Invert = result.JoystickAxisValue < 0.0f;
    //             inputAction.Bindings[0].Axis = result.JoystickAxis;
    //         }

    //         return true;
    //     });
    // }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Luminosity.IO;
using TMPro;

public class SettingButtonBehaviour : MonoBehaviour
{
    public string ButtonAction;
    public string[] axisList = {"joy_0_axis_0", "joy_0_axis_1", "joy_0_axis_2", "joy_0_axis_3", "joy_0_axis_4", "joy_0_axis_5", "joy_0_axis_6", "joy_0_axis_7", "joy_0_axis_8", "joy_0_axis_9", "joy_0_axis_10", "joy_0_axis_11", "joy_0_axis_12", "joy_0_axis_13", "joy_0_axis_14", "joy_0_axis_15", "joy_0_axis_16", "joy_0_axis_17", "joy_0_axis_18", "joy_0_axis_19", "joy_0_axis_20", "joy_0_axis_21", "joy_0_axis_22", "joy_0_axis_23", "joy_0_axis_24", "joy_0_axis_25", "joy_0_axis_26", "joy_0_axis_27", "joy_1_axis_0", "joy_1_axis_1", "joy_1_axis_2", "joy_1_axis_3", "joy_1_axis_4", "joy_1_axis_5", "joy_1_axis_6", "joy_1_axis_7", "joy_1_axis_8", "joy_1_axis_9", "joy_1_axis_10", "joy_1_axis_11", "joy_1_axis_12", "joy_1_axis_13", "joy_1_axis_14", "joy_1_axis_15", "joy_1_axis_16", "joy_1_axis_17", "joy_1_axis_18", "joy_1_axis_19", "joy_1_axis_20", "joy_1_axis_21", "joy_1_axis_22", "joy_1_axis_23", "joy_1_axis_24", "joy_1_axis_25", "joy_1_axis_26", "joy_1_axis_27", "joy_2_axis_0", "joy_2_axis_1", "joy_2_axis_2", "joy_2_axis_3", "joy_2_axis_4", "joy_2_axis_5", "joy_2_axis_6", "joy_2_axis_7", "joy_2_axis_8", "joy_2_axis_9", "joy_2_axis_10", "joy_2_axis_11", "joy_2_axis_12", "joy_2_axis_13", "joy_2_axis_14", "joy_2_axis_15", "joy_2_axis_16", "joy_2_axis_17", "joy_2_axis_18", "joy_2_axis_19", "joy_2_axis_20", "joy_2_axis_21", "joy_2_axis_22", "joy_2_axis_23", "joy_2_axis_24", "joy_2_axis_25", "joy_2_axis_26", "joy_2_axis_27", "joy_3_axis_0", "joy_3_axis_1", "joy_3_axis_2", "joy_3_axis_3", "joy_3_axis_4", "joy_3_axis_5", "joy_3_axis_6", "joy_3_axis_7", "joy_3_axis_8", "joy_3_axis_9", "joy_3_axis_10", "joy_3_axis_11", "joy_3_axis_12", "joy_3_axis_13", "joy_3_axis_14", "joy_3_axis_15", "joy_3_axis_16", "joy_3_axis_17", "joy_3_axis_18", "joy_3_axis_19", "joy_3_axis_20", "joy_3_axis_21", "joy_3_axis_22", "joy_3_axis_23", "joy_3_axis_24", "joy_3_axis_25", "joy_3_axis_26", "joy_3_axis_27", "joy_4_axis_0", "joy_4_axis_1", "joy_4_axis_2", "joy_4_axis_3", "joy_4_axis_4", "joy_4_axis_5", "joy_4_axis_6", "joy_4_axis_7", "joy_4_axis_8", "joy_4_axis_9", "joy_4_axis_10", "joy_4_axis_11", "joy_4_axis_12", "joy_4_axis_13", "joy_4_axis_14", "joy_4_axis_15", "joy_4_axis_16", "joy_4_axis_17", "joy_4_axis_18", "joy_4_axis_19", "joy_4_axis_20", "joy_4_axis_21", "joy_4_axis_22", "joy_4_axis_23", "joy_4_axis_24", "joy_4_axis_25", "joy_4_axis_26", "joy_4_axis_27", "joy_5_axis_0", "joy_5_axis_1", "joy_5_axis_2", "joy_5_axis_3", "joy_5_axis_4", "joy_5_axis_5", "joy_5_axis_6", "joy_5_axis_7", "joy_5_axis_8", "joy_5_axis_9", "joy_5_axis_10", "joy_5_axis_11", "joy_5_axis_12", "joy_5_axis_13", "joy_5_axis_14", "joy_5_axis_15", "joy_5_axis_16", "joy_5_axis_17", "joy_5_axis_18", "joy_5_axis_19", "joy_5_axis_20", "joy_5_axis_21", "joy_5_axis_22", "joy_5_axis_23", "joy_5_axis_24", "joy_5_axis_25", "joy_5_axis_26", "joy_5_axis_27", "joy_6_axis_0", "joy_6_axis_1", "joy_6_axis_2", "joy_6_axis_3", "joy_6_axis_4", "joy_6_axis_5", "joy_6_axis_6", "joy_6_axis_7", "joy_6_axis_8", "joy_6_axis_9", "joy_6_axis_10", "joy_6_axis_11", "joy_6_axis_12", "joy_6_axis_13", "joy_6_axis_14", "joy_6_axis_15", "joy_6_axis_16", "joy_6_axis_17", "joy_6_axis_18", "joy_6_axis_19", "joy_6_axis_20", "joy_6_axis_21", "joy_6_axis_22", "joy_6_axis_23", "joy_6_axis_24", "joy_6_axis_25", "joy_6_axis_26", "joy_6_axis_27", "joy_7_axis_0", "joy_7_axis_1", "joy_7_axis_2", "joy_7_axis_3", "joy_7_axis_4", "joy_7_axis_5", "joy_7_axis_6", "joy_7_axis_7", "joy_7_axis_8", "joy_7_axis_9", "joy_7_axis_10", "joy_7_axis_11", "joy_7_axis_12", "joy_7_axis_13", "joy_7_axis_14", "joy_7_axis_15", "joy_7_axis_16", "joy_7_axis_17", "joy_7_axis_18", "joy_7_axis_19", "joy_7_axis_20", "joy_7_axis_21", "joy_7_axis_22", "joy_7_axis_23", "joy_7_axis_24", "joy_7_axis_25", "joy_7_axis_26", "joy_7_axis_27", "joy_8_axis_0", "joy_8_axis_1", "joy_8_axis_2", "joy_8_axis_3", "joy_8_axis_4", "joy_8_axis_5", "joy_8_axis_6", "joy_8_axis_7", "joy_8_axis_8", "joy_8_axis_9", "joy_8_axis_10", "joy_8_axis_11", "joy_8_axis_12", "joy_8_axis_13", "joy_8_axis_14", "joy_8_axis_15", "joy_8_axis_16", "joy_8_axis_17", "joy_8_axis_18", "joy_8_axis_19", "joy_8_axis_20", "joy_8_axis_21", "joy_8_axis_22", "joy_8_axis_23", "joy_8_axis_24", "joy_8_axis_25", "joy_8_axis_26", "joy_8_axis_27", "joy_9_axis_0", "joy_9_axis_1", "joy_9_axis_2", "joy_9_axis_3", "joy_9_axis_4", "joy_9_axis_5", "joy_9_axis_6", "joy_9_axis_7", "joy_9_axis_8", "joy_9_axis_9", "joy_9_axis_10", "joy_9_axis_11", "joy_9_axis_12", "joy_9_axis_13", "joy_9_axis_14", "joy_9_axis_15", "joy_9_axis_16", "joy_9_axis_17", "joy_9_axis_18", "joy_9_axis_19", "joy_9_axis_20", "joy_9_axis_21", "joy_9_axis_22", "joy_9_axis_23", "joy_9_axis_24", "joy_9_axis_25", "joy_9_axis_26", "joy_9_axis_27", "joy_10_axis_0", "joy_10_axis_1", "joy_10_axis_2", "joy_10_axis_3", "joy_10_axis_4", "joy_10_axis_5", "joy_10_axis_6", "joy_10_axis_7", "joy_10_axis_8", "joy_10_axis_9", "joy_10_axis_10", "joy_10_axis_11", "joy_10_axis_12", "joy_10_axis_13", "joy_10_axis_14", "joy_10_axis_15", "joy_10_axis_16", "joy_10_axis_17", "joy_10_axis_18", "joy_10_axis_19", "joy_10_axis_20", "joy_10_axis_21", "joy_10_axis_22", "joy_10_axis_23", "joy_10_axis_24", "joy_10_axis_25", "joy_10_axis_26", "joy_10_axis_27"};    
    public void Start()
    {
        InputAction inputAction = InputManager.GetAction("CustomControls", ButtonAction);
        if (inputAction.Bindings[0].Type == InputType.Button) {
            GetComponentInChildren<TextMeshProUGUI>().text = inputAction.Bindings[0].Positive.ToString();
        } else {
            GetComponentInChildren<TextMeshProUGUI>().text = "Axis: " + inputAction.Bindings[0].Axis.ToString();
        }
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
            Debug.Log(inputAction);
            inputAction.Bindings[0].Positive = result.Key;
            Debug.Log("Scan complete: " + result.Key.ToString() + ".");
            InputManager.Save();
            Debug.Log("Saved.");
            GetComponentInChildren<TextMeshProUGUI>().text = result.Key.ToString();
            Debug.Log("Changed button text.");
            return true;
        });
    }

private int getButton(int[] input) {
    // input[0] == joystick number
    // input[1] == button number
    // start joystick button at 350
    // joystick [number] button [number]
    int start = 350;
    Debug.Log(input[0]);
    Debug.Log(input[1]);
    start += (input[0] - 1) * 20 + input[1] - 330;
    Debug.Log("start: " + start);

    return start;
}

public void changeJoystickButton()
    {
        ScanSettings settings = new ScanSettings
        {
            ScanFlags = ScanFlags.JoystickButton,
            // If the player presses this key the scan will be canceled.
            CancelScanKey = KeyCode.Escape,
            // If the player doesn't press any key within the specified number
            // of seconds the scan will be canceled.
            Timeout = 10
        };

        // You can replace the lambda function with a member function if you want.
        InputManager.StartInputScan(settings, result =>
        {
            // The handle should return "true" if the button is accepted or "false" if the button is rejected.
            // If the button is rejected the scan will continue until a button is accepted or until the timeout expires.
            Debug.Log("start scanning");
            // Debug.Log(ButtonAction);
            // Debug.Log(result.ScanFlags);
            // Debug.Log(ScanFlags.JoystickButton);
            Debug.Log("got button: " + result.Key.ToString());
            Debug.Log("got joystick: " + result.Joystick.ToString());
            int[] input = new int[2];
            input[0] = (int)result.Joystick;
            input[1] = (int)result.Key;
            KeyCode positive = (KeyCode)getButton(input);

            /*if((int)result.Key < (int)KeyCode.Joystick1Button0 || (int)result.Key > (int)KeyCode.Joystick8Button19) {
                // Debug.Log("3");
                return false;
                }*/
            InputAction inputAction = InputManager.GetAction("CustomControls", ButtonAction);
            inputAction.Bindings[0].Type = InputType.Button;
            //Debug.Log("8");
            inputAction.Bindings[0].Positive = positive;
            InputManager.Save();
            GetComponentInChildren<TextMeshProUGUI>().text = inputAction.Bindings[0].Positive.ToString();
            Debug.Log("true");
            return true;
        });
    }

private string[] getJoystick(string input) {
    input = input.Replace("joy_", "");
    input = input.Replace("_axis_", "?");
    string[] joystick = input.Split('?');
    return joystick;
}

public void changeJoystickAxis()
    {
        ScanSettings settings = new ScanSettings
        {
            ScanFlags = ScanFlags.JoystickAxis,
            // If the player presses this key the scan will be canceled.
            CancelScanKey = KeyCode.Escape,
            // If the player doesn't press any key within the specified number
            // of seconds the scan will be canceled.
            Timeout = 2
        };

        // You can replace the lambda function with a member function if you want.
        InputManager.StartInputScan(settings, result =>
        {
            Debug.Log("axis0: "+Input.GetAxis("joy_0_axis_0")); //correct
            Debug.Log("start scanning");
            Debug.Log(InputManager.GetAxis("Throttle")); //correct
            Debug.Log(result.JoystickAxisValue);
            InputAction inputAction = InputManager.GetAction("CustomControls", ButtonAction);
            //inputAction.Bindings[0].Axis = InputManager.GetAxis("Throttle");
            //inputAction.Bindings[0].Invert = result.JoystickAxisValue < 0.0f;
            //inputAction.Bindings[0].Axis = result.JoystickAxis;
            Debug.Log(inputAction.Bindings[0].Axis);
            //Debug.Log(result.JoystickAxis);
            foreach (string element in axisList)
            {
                //if (Input.GetAxis(element) > 0.5) {
                if (Input.GetAxis(element) < -0.5) {
                    //Debug.Log("found axis");
                    string[] joyParameters = getJoystick(element);
                    string joy = joyParameters[0];
                    string axis = joyParameters[1];
                    Debug.Log(element);
                    Debug.Log("joy: " + joy + " axis:" + axis);
                    Debug.Log(Input.GetAxis(element));
                    inputAction.Bindings[0].Joystick = int.Parse(joy);
                    inputAction.Bindings[0].Axis = int.Parse(axis);
                    InputManager.Save();
                }
            }

            GetComponentInChildren<TextMeshProUGUI>().text = "Axis: " + inputAction.Bindings[0].Axis.ToString();
            Debug.Log("true");
            return true;
        });
   }
}

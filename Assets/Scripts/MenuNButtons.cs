using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sett = SettingsJSON.Settings;
using System.IO;


/*  https://gamedev.stackexchange.com/questions/172842/unity-menu-navigation-using-keyboard-controller-input */
public class MenuNButtons : MonoBehaviour
{
    public Button[] options;

    private int currentSelection;
    private int numberOfOptions;
    private Sett currentSettings = new Sett();
    // Start is called before the first frame update
    void Start()
    {
        currentSelection = 0;
        numberOfOptions = options.Length;
        foreach( Button b in options ){
            b.image.color = new Color32(0, 0, 0, 100);
        }
        options[currentSelection].image.color = new Color32(255, 255, 255, 255);
        StreamReader sr = new StreamReader("Assets/Resources/settings.json");
        currentSettings = JsonUtility.FromJson<Sett>(sr.ReadLine());
        sr.Close();
    }

    // Update is called once per frame
    void Update()
    {
        StreamReader sr = new StreamReader("Assets/Resources/settings.json");
        currentSettings = JsonUtility.FromJson<Sett>(sr.ReadLine());
        sr.Close();
        if (Input.GetKeyDown(currentSettings.ForwardKey) /*|| Controller input*/)
        { //Input telling it to go up or down.
            currentSelection = (currentSelection + 1)%numberOfOptions;
            foreach( Button b in options ){
                b.image.color = new Color32(0, 0, 0, 100);
            }
            options[currentSelection].image.color = new Color32(255, 255, 255, 255);
        }

        if (Input.GetKeyDown(currentSettings.BackKey) /*|| Controller input*/)
        { //Input telling it to go up or down.
            currentSelection = (currentSelection - 1 + numberOfOptions)%numberOfOptions;
            foreach( Button b in options ){
                b.image.color = new Color32(0, 0, 0, 100);
            }
            options[currentSelection].image.color = new Color32(255, 255, 255, 255);
        }

        if (Input.GetKeyDown(currentSettings.EnterKey) || Input.GetKeyDown("joystick button 1")){ //For testing as the switch statement does nothing right now.
            Debug.Log("Picked: " + currentSelection);
            options[currentSelection].onClick.Invoke();
        }
    }
}

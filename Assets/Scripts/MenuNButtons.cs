using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*  https://gamedev.stackexchange.com/questions/172842/unity-menu-navigation-using-keyboard-controller-input */
public class MenuNButtons : MonoBehaviour
{
    public Button[] options;

    private int currentSelection;
    private int numberOfOptions;
    // Start is called before the first frame update
    void Start()
    {
        currentSelection = 0;
        numberOfOptions = options.Length;
        foreach( Button b in options ){
            b.image.color = new Color32(0, 0, 0, 100);
        }
        options[currentSelection].image.color = new Color32(255, 255, 255, 255);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) /*|| Controller input*/)
        { //Input telling it to go up or down.
            currentSelection = (currentSelection + 1)%numberOfOptions;
            foreach( Button b in options ){
                b.image.color = new Color32(0, 0, 0, 100);
            }
            options[currentSelection].image.color = new Color32(255, 255, 255, 255);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) /*|| Controller input*/)
        { //Input telling it to go up or down.
            currentSelection = (currentSelection - 1 + numberOfOptions)%numberOfOptions;
            foreach( Button b in options ){
                b.image.color = new Color32(0, 0, 0, 100);
            }
            options[currentSelection].image.color = new Color32(255, 255, 255, 255);
        }

        if (Input.GetKeyDown(KeyCode.Return) ){ //For testing as the switch statment does nothing right now.
            Debug.Log("Picked: " + currentSelection);
        }
    }
}

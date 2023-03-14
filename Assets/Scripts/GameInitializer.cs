using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* These two methods are always run when a game is loaded, without action from the user.
 * It can be used for setting up all kind of behaviour necesarry when a player starts playing the game. */
public class GameInitializer : MonoBehaviour
{
    public InputField PasswordInputField;

    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        
    }

    [RuntimeInitializeOnLoadMethod]
    static void OnSecondRuntimeMethodLoad()
    {
        
    }
}

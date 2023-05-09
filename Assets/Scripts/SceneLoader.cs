using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadProfileScene() {
        GameObject gco = GameObject.Find("GameControllerObj");  // GameControllerObj should be in DontDestroyOnLoad
        GameController gc = (GameController) gco.GetComponent(typeof(GameController));
        if (gc.login) {
            LoadScene("menu_profile");
        }
        else {
            LoadScene("menu_login");
        }
    }
}
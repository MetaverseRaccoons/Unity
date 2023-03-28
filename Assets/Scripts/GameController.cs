using UnityEngine;

public class GameController : MonoBehaviour
{
    public SceneLoader sl;
    public ViolationsController vc;
    public LoginController lc;

    public void Awake() {
        // transform.gameObject returns the gameObject that this script is attached to in Unity
        print("Game loading...");

        DontDestroyOnLoad(transform.gameObject);
        this.sl = transform.gameObject.AddComponent<SceneLoader>();
        this.vc = transform.gameObject.AddComponent<ViolationsController>();
        this.lc = transform.gameObject.AddComponent<LoginController>();
        
        this.sl.LoadScene("menu_main");
    }

    /* This function is necessary because Debug.Log does not work in Awake() */
    public void print(string str)
    {
        Debug.Log(str);
    }
}
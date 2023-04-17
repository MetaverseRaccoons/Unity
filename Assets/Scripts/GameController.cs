using UnityEngine;
using System.Security.Cryptography;

/// <summary>
///  This class keeps instances of all Controller scripts so the same instances of them can be used accross all scenes.
///  It is instantiated when the game is loaded and should not be destroyed to work properly.
/// </summary>
public class GameController : MonoBehaviour
{
    public SceneLoader sl;
    public ViolationsController vc;
    public LoginController lc;
    public EncryptionController ec;
    public Aes aes;
    public StatsController sc;

    public void Awake() {
        // transform.gameObject returns the gameObject that this script is attached to in Unity
        print("Game loading...");

        DontDestroyOnLoad(transform.gameObject);
        this.sl = transform.gameObject.AddComponent<SceneLoader>();
        this.vc = transform.gameObject.AddComponent<ViolationsController>();
        this.lc = transform.gameObject.AddComponent<LoginController>();
        this.ec = transform.gameObject.AddComponent<EncryptionController>();
        this.aes = Aes.Create();
        this.sc = transform.gameObject.AddComponent<StatsController>();

        this.sl.LoadScene("menu_main");
    }

    /* This function is necessary because Debug.Log does not work in Awake() */
    public void print(string str)
    {
        Debug.Log(str);
    }
}
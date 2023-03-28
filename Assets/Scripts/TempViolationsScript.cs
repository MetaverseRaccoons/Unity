using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempViolationsScript : MonoBehaviour
{

    void Awake() {
        GameObject gco = GameObject.Find("GameControllerObj");  // GameControllerObj should be in DontDestroyOnLoad
        GameController gc = (GameController) gco.GetComponent(typeof(GameController));
        StartCoroutine(gc.vc.RequestAddViolation("speeding", "0.75", "Speeding in a 30km/h zone"));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  This temporary script is used to test the violations functionality regarding communication with backend.
/// </summary>
public class TestBackendScript : MonoBehaviour
{

    void Awake() {
        GameObject gco = GameObject.Find("GameControllerObj");  // GameControllerObj should be in DontDestroyOnLoad
        GameController gc = (GameController) gco.GetComponent(typeof(GameController));
        
        // StartCoroutine(gc.vc.RequestAddViolation("speeding", "0.75", "Speeding in a 30km/h zone"));
        StartCoroutine(gc.sc.RequestAddKilometers(5.0f));
        StartCoroutine(gc.sc.RequestAddMinutes(37.0f));
        // StartCoroutine(gc.pc.RequestProfileInformation());
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

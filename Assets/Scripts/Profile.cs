using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Profile : MonoBehaviour
{
    public TMP_Text usernameLabel;
    public TMP_Text emailLabel;
    public TMP_Text profileType;
    public TMP_Text hasDriverLicenseLabel;
    public TMP_Text isShareableLabel;
    public TMP_Text kmDrivenLabel;
    public TMP_Text minutesDrivenLabel;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateLabels());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator UpdateLabels() {
        GameObject gco = GameObject.Find("GameControllerObj");  // GameControllerObj should be in DontDestroyOnLoad
        GameController gc = (GameController) gco.GetComponent(typeof(GameController));
        yield return StartCoroutine(gc.pc.RequestProfileInformation());

        // Once the coroutine has finished, update the labels
        usernameLabel.text = gc.user.username;
        emailLabel.text = gc.user.email;
        if (gc.user.is_learner == "True") {
            profileType.text = "Learner";
        } else if (gc.user.is_instructor == "True") {
            profileType.text = "Instructor";
        }
        hasDriverLicenseLabel.text = gc.user.has_drivers_license == "True" ? "Yes" : "No";
        isShareableLabel.text = gc.user.is_shareable == "True" ? "Yes" : "No";
        kmDrivenLabel.text = gc.user.km_driven.Length == 0 ? "/" : gc.user.km_driven;
        minutesDrivenLabel.text = gc.user.minutes_driven.Length == 0 ? "/" : gc.user.minutes_driven;
    }
}

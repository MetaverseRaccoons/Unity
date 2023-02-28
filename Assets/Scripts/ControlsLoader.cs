using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Luminosity.IO;

public class ControlsLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InputManager.Load();
    }
}

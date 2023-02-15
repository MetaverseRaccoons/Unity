using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Reflection;
using conv = System.Convert;
using System.ComponentModel;

public class SettingsJSON : MonoBehaviour
{
    public TextAsset JSONtext;

    [System.Serializable]
    public class Settings
    {
        public KeyCode ForwardKey;
        public KeyCode BackKey;
        public KeyCode LeftKey;
        public KeyCode RightKey;
        public KeyCode EnterKey;
    }

    public static Settings mySettings = new Settings();

    void Start()
    {
        if( JSONtext.text == "" ){
            string path = "Assets/Resources/settings.json";
            var startsettings = new Settings(){
                ForwardKey = KeyCode.UpArrow, 
                BackKey = KeyCode.DownArrow,
                LeftKey = KeyCode.LeftArrow,
                RightKey = KeyCode.RightArrow,
                EnterKey = KeyCode.Return};
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine(JsonUtility.ToJson(startsettings));
            writer.Close();
        }else{ 
            Debug.Log(JSONtext.text);
            mySettings = JsonUtility.FromJson<Settings>(JSONtext.text);
        }
    }

    Settings getSettings(){
        return mySettings;
    }
}

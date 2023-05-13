using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "SaveData", menuName = "Data/SaveData")]
public class SaveData : ScriptableObject
{
    public static bool whiteblock = false;
    public static bool redblock = false;
    public static bool blueblock = false;
    public static bool greenblock = false;
    public static bool purpleblock = false;

    public static bool invokecount = true;
}


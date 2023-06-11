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

    public static int stagecount = -1;
    public static int tutorialcount = 0;

    public static bool vacant = false;
    public static bool isPause = false;

    public static bool elementReact = false;

    public static bool specialblock = false;

    public static bool specialreact = false;

    public static bool TutoClear = false;
    public static bool Stage1Clear = false;
    public static bool Stage2Clear = false;
    public static bool BossClear = false;

    public static bool cautionCount = true;
}


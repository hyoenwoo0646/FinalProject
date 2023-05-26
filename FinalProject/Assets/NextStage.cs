using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
   public void next()
    {
        SaveData.stagecount = 1;
        SceneManager.LoadScene("Stage1");
    }

    public void next2()
    {
        SaveData.stagecount = 2;
        SceneManager.LoadScene("FinalStage");
    }

    public void next3()
    {
        SceneManager.LoadScene("Title");
        SaveData.TutoClear = false;
        SaveData.Stage1Clear = false;
        SaveData.Stage2Clear = false;
        SaveData.BossClear = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public void GoTutorial()
    {
        SaveData.stagecount = -1;
        SceneManager.LoadScene("Tutorial");
    }

    public void GoStage1()
    {
        SaveData.stagecount = 0;
        SceneManager.LoadScene("MainScene");        
    }
}

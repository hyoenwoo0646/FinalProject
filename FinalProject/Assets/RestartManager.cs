using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour
{
    public void Restart()
    {
        SaveData.stagecount = 0;
        SceneManager.LoadScene("MainScene");
    }

    public void Restart2()
    {
        SaveData.stagecount = 1;
        SceneManager.LoadScene("Stage1");
    }

    public void Restart3()
    {
        SaveData.stagecount = 2;
        SceneManager.LoadScene("FinalStage");
    }
}

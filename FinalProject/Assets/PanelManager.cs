using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    public GameObject panel;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveData.isPause == true)
        {
            PauseGame();
        }

        if(SaveData.vacant == true)
        {
            panel2.SetActive(true);
            SaveData.isPause = true;
        }

        if (SaveData.elementReact == true && panel2.activeSelf == false)
        {
            panel3.SetActive(true);
            SaveData.isPause = true;
        }

        if(SaveData.specialblock == true)
        {
            panel4.SetActive(true);
            SaveData.isPause = true;
        }

        if(SaveData.specialreact == true)
        {
            panel5.SetActive(true);
            SaveData.isPause = true;
        }
    }


    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
        
        SaveData.isPause = false;
    }

    public void Offpanel()
    {
        panel.SetActive(false);
        ResumeGame();
    }
    public void Offpanel2()
    {
        panel2.SetActive(false);
        SaveData.vacant = false;
        ResumeGame();
    }
    public void Offpanel3()
    {
        panel3.SetActive(false);
        SaveData.elementReact = false;
        ResumeGame();
    }
    public void Offpanel4()
    {
        panel4.SetActive(false);
        SaveData.specialblock = false;
        ResumeGame();
    }

    public void GameStart()
    {
        SaveData.isPause = false;
        SaveData.stagecount = 0;
        SceneManager.LoadScene("MainScene");
    }
}

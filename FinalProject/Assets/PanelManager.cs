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
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(SaveData.vacant == true)
        {
            panel2.SetActive(true);
        }

        if (SaveData.elementReact == true && panel2.activeSelf == false)
        {
            panel3.SetActive(true);
        }

        if(SaveData.specialblock == true)
        {
            panel4.SetActive(true);
        }

        if(SaveData.specialreact == true && panel4.activeSelf == false)
        {
            panel5.SetActive(true);
        }
    }

    public void Offpanel()
    {
        SaveData.tutorialcount = 1;
        panel.SetActive(false);
    }
    public void Offpanel2()
    {
        SaveData.tutorialcount = 2;
        panel2.SetActive(false);
        SaveData.vacant = false;
    }
    public void Offpanel3()
    {
        SaveData.tutorialcount = 3;
        panel3.SetActive(false);
        SaveData.elementReact = false;
    }
    public void Offpanel4()
    {
        SaveData.tutorialcount = 4;
        panel4.SetActive(false);
        SaveData.specialblock = false;
    }

    public void GameStart()
    {
        SaveData.stagecount = 0;
        SceneManager.LoadScene("MainScene");
    }
}

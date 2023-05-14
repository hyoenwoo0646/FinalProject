using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{


    private bool isPause = true;
    private bool isPause2 = true;
    private bool isPause3 = true;
    private bool isPause4 = true;

    public GameObject panel;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject button;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPause)
        {
            PauseGame();


        }
        
        if (BlockRoot.Instance.TutorialCount > 2 && GiveElement.Instance.Active == true && isPause3 && !isPause)
        {
            Debug.Log("아란ㅇ라나");
            panel3.gameObject.SetActive(true);
            PauseGame();
            isPause3 = false;
        }

        if (BlockRoot.Instance.TutorialCount > 5 && isPause2)
        {
            panel2.gameObject.SetActive(true);
            PauseGame();
            isPause2 = false;
        }

        if (BlockRoot.Instance.TutorialCount > 2 && GiveElement.Instance.Active == true && GiveElement.Instance.Active2 == true && isPause4 && !isPause)
        {
            panel4.gameObject.SetActive(true);
            PauseGame();
            isPause4 = false;
        }
    }


    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
        isPause = false;
    }

    public void Offpanel()
    {
        panel.SetActive(false);
        ResumeGame();
    }
    public void Offpanel2()
    {
        panel2.SetActive(false);
        ResumeGame();
    }
    public void Offpanel3()
    {
        panel3.SetActive(false);
        ResumeGame();
    }
    public void Offpanel4()
    {
        panel4.SetActive(false);
        ResumeGame();
    }
}

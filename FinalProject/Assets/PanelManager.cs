using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{


    private bool isPause = true;

    public GameObject panel;
    public GameObject panel2;
    public GameObject button;
    public GameObject button2;

    
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
            panel.gameObject.SetActive(true);
            
            if(button.gameObject.activeSelf == false)
            {
                Debug.Log("dasda");
                panel.gameObject.SetActive(false);
                ResumeGame();
            }
            
        }


        if (BlockRoot.Instance.TutorialCount > 5)
        {
            PauseGame();
            panel2.gameObject.SetActive(true);
            if (button2.gameObject.activeSelf == false)
            {
                panel2.gameObject.SetActive(false);
                ResumeGame();
            }

        }
    }


    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void Offpanel()
    {
        panel.SetActive(false);
        Debug.Log("dasda3324");
    }
}

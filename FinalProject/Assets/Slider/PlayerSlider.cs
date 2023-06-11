using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSlider : MonoBehaviour
{
    private static PlayerSlider instance = null;

    public static PlayerSlider Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public Slider playerSlider;
    public GameObject fill;
    public GameObject panel;
    public GameObject Button;

    public bool playgame = false;
    public int hpFull;
    public int hpCurrent;

    GameObject cautionText;

    public int bossdamage;
    public int stuntime;

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }

        hpCurrent = 100;
        hpFull = 100;
        bossdamage = 5;
    }
    IEnumerator MyCoroutine()
    {
        
        yield return new WaitForSeconds(3.0f);
       
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MyCoroutine());
        InvokeRepeating("hpdown", 3f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if(hpCurrent >= 100)
        {
            hpCurrent = 100;
        }

        playerSlider.value = (float)hpCurrent / hpFull;
        if (SaveData.invokecount == false)
        {
            bossdamage = 0;
            Invoke("clearstun", stuntime);
            SaveData.invokecount = true;
        }

        if(SaveData.stagecount == -1)
        {
            CancelInvoke("hpdown");
        }
        if(SaveData.stagecount == 0 && SaveData.Stage1Clear == true)
        {
            CancelInvoke("hpdown");
        }
        if(SaveData.stagecount == 1 && SaveData.Stage2Clear == true)
        {
            CancelInvoke("hpdown");
        }
        if(SaveData.stagecount == 2 && SaveData.BossClear == true)
        {
            CancelInvoke("hpdown");
        }

        if (playerSlider.value <= 0)
        {
            SoundManager.Instance.LoseSound();
            fill.SetActive(false);
            panel.SetActive(true);            
        }

        if(playerSlider.value <= 0.3 && SaveData.cautionCount == true)
        {
            cautionTextUp();
            SaveData.cautionCount = false;
        }

        if(playerSlider.value > 0.3)
        {
            CancelInvoke("caution");
            SaveData.cautionCount = true;
        }
    }

    void hpdown()
    {
        hpCurrent = hpCurrent - bossdamage;
        SoundManager.Instance.PlayRandomSound();
        SoundManager.Instance.PlayDamageRandomSound();
    }

    void clearstun()
    {
        
        bossdamage = 5;
    }

    void cautionTextUp()
    {
        InvokeRepeating("caution", 0f, 2f);
    }

    void caution()
    {
        DamageText.Instance.CreateCautionText(Camera.main.WorldToScreenPoint(new Vector3(7.0f, 1.0f, 0)));

    }
}

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


        playerSlider.value = (float)hpCurrent / hpFull;
            if (SaveData.invokecount == false)
            {
                bossdamage = 0;
                Invoke("clearstun", stuntime);
                SaveData.invokecount = true;
            }

            if (playerSlider.value <= 0)
            {
                fill.SetActive(false);
                panel.SetActive(true);
            }
        

        
        

    }

    void hpdown()
    {
        hpCurrent = hpCurrent - bossdamage;
    }

    void clearstun()
    {
        bossdamage = 5;
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalBossSlider : MonoBehaviour
{
    private static FinalBossSlider instance = null;

    public static FinalBossSlider Instance
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

    public Slider bossSlider;
    public Slider fireshieldSlider;
    public Slider watershieldSlider;

    public GameObject fill;
    public GameObject fireshieldfill;
    public GameObject watershieldfill;
    public GameObject Panel;

    public int hpFull;
    public int hpCurrent;

    public int fireshieldFull;
    public int fireshieldCurrent;

    public int watershieldFull;
    public int watershieldCurrent;
    public bool Final_is_win = false;

    int damagecount;

    int totalscore;
    int damage;
    int finalDamage;
    int temp = 0;

    public int damagePlus = 0;

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }

        fireshieldCurrent = 300;
        fireshieldFull = 300;

        watershieldCurrent = 300;
        watershieldFull = 300;

        hpCurrent = 3000;
        hpFull = 3000;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bossSlider.value = (float)hpCurrent / hpFull;
        fireshieldSlider.value = (float)fireshieldCurrent / fireshieldFull;
        watershieldSlider.value = (float)watershieldCurrent / watershieldFull;


        totalscore = ScoreCounter.Instance.last.total_socre;
        if (temp == 0)
        {
            temp = totalscore;

            damage = temp;
            finalDamage = damage + damagePlus;


            if (fireshieldCurrent >= 0)
            {
                if (SaveData.redblock == false)
                {
                    fireshieldCurrent -= finalDamage;

                    temp = totalscore;
                }

                if (SaveData.redblock == true)
                {
                    finalDamage = 0;
                    fireshieldCurrent -= finalDamage;
                    temp = totalscore;
                }
            }

            else if (fireshieldCurrent <= 0)
            {
                hpCurrent -= finalDamage;
                watershieldSlider.gameObject.SetActive(true);
                fireshieldSlider.gameObject.SetActive(false);
                temp = totalscore;
            }

            damagecount = 1;
            if (damagecount == 1)
            {
                DamageText.Instance.CreateDamageText(Camera.main.WorldToScreenPoint(new Vector3(0, 5.5f, 0)), finalDamage);
                damagecount = 0;
            }
        }
        if (temp != totalscore)
        {
            damage = totalscore - temp;
            finalDamage = damage + damagePlus;

            if (fireshieldCurrent >= 0)
            {
                if (SaveData.redblock == false)
                {
                    fireshieldCurrent -= finalDamage;

                    temp = totalscore;
                }

                if(SaveData.redblock == true)
                {
                    finalDamage = 0;
                    fireshieldCurrent -= finalDamage;
                    temp = totalscore;
                }
            }

            else if (fireshieldCurrent <= 0)
            {

                watershieldSlider.gameObject.SetActive(true);
                fireshieldSlider.gameObject.SetActive(false);
                temp = totalscore;
            }

            if(fireshieldSlider.gameObject.activeSelf == false && watershieldCurrent >= 0)
            {
                if (SaveData.blueblock == false)
                {
                    watershieldCurrent -= finalDamage;

                    temp = totalscore;
                }

                if (SaveData.blueblock == true)
                {
                    finalDamage = 0;
                    watershieldCurrent -= finalDamage;
                    temp = totalscore;
                }
            }

            else if(fireshieldSlider.gameObject.activeSelf == false && watershieldCurrent <= 0)
            {               
                watershieldSlider.gameObject.SetActive(false);              
            }

            if(fireshieldSlider.gameObject.activeSelf == false && watershieldSlider.gameObject.activeSelf == false)
            {
                hpCurrent -= finalDamage;
                temp = totalscore;
            }

            damagecount = 1;
            if (damagecount == 1)
            {
                DamageText.Instance.CreateDamageText(Camera.main.WorldToScreenPoint(new Vector3(0, 5.5f, 0)), finalDamage);
                damagecount = 0;
            }


        }


        if (bossSlider.value <= 0)
        {
            fill.SetActive(false);
            Panel.SetActive(true);
            Final_is_win = true;
        }

        if (fireshieldSlider.value <= 0)
        {
            fireshieldfill.SetActive(false);
        }
    }
}

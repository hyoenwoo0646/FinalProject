using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondBossSlider : MonoBehaviour
{
    private static SecondBossSlider instance = null;

    public static SecondBossSlider Instance
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

    public GameObject fill;
    public GameObject fireshieldfill;

    public int hpFull;
    public int hpCurrent;

    public int fireshieldFull;
    public int fireshieldCurrent;

    int damagecount;

    int shieldDefense = 10;

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

        hpCurrent = 2000;
        hpFull = 2000;
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
                }
            }

            else if (fireshieldCurrent <= 0)
            {
                hpCurrent -= finalDamage;
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
            }

            else if (fireshieldCurrent <= 0)
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
        }

        if (fireshieldSlider.value <= 0)
        {
            fireshieldfill.SetActive(false);
        }
    }
}

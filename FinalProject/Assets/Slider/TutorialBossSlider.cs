using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialBossSlider : MonoBehaviour
{
    private static TutorialBossSlider instance = null;

    public static TutorialBossSlider Instance
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

    public GameObject fill;

    public int hpFull;
    public int hpCurrent;


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

        hpCurrent = 2000;
        hpFull = 2000;
    }
    // Start is called before the first frame update
    void Start()
    {
        ScoreCounter.Instance.last.total_socre = 0;
    }

    // Update is called once per frame
    void Update()
    {
        bossSlider.value = (float)hpCurrent / hpFull;


        totalscore = ScoreCounter.Instance.last.total_socre;
        if (temp == 0)
        {
            temp = totalscore;

            damage = temp;
            finalDamage = damage + damagePlus;
            hpCurrent -= finalDamage;

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
            hpCurrent -= finalDamage;

            damagecount = 1;
            if (damagecount == 1)
            {
                DamageText.Instance.CreateDamageText(Camera.main.WorldToScreenPoint(new Vector3(0, 5.5f, 0)), finalDamage);
                damagecount = 0;
            }

            temp = totalscore;
        }


        if (bossSlider.value <= 0)
        {
            SoundManager.Instance.WinSound();
            fill.SetActive(false);
            SaveData.TutoClear = true;
        }

    }
}

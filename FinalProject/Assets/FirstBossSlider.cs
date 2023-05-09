using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstBossSlider : MonoBehaviour
{
    private static FirstBossSlider instance = null;

    public static FirstBossSlider Instance
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


    int totalscore;
    int damage;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        bossSlider.value = (float)hpCurrent / hpFull;


        totalscore = ScoreCounter.Instance.last.total_socre;
        if(temp == 0)
        {
            temp = totalscore;

            damage = temp;
            hpCurrent -= damage + damagePlus;
        }
        if(temp != totalscore)
        {
            damage = totalscore - temp;
            hpCurrent -= damage + damagePlus;

            temp = totalscore;
        }


        if(bossSlider.value == 0)
        {
            fill.SetActive(false);
        }
    }
}

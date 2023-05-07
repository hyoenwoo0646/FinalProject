using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstBossSlider : MonoBehaviour
{
    public Slider bossSlider;
    public GameObject fill;

    public int hpFull;
    public int hpCurrent;


    int totalscore;
    int damage;
    int temp = 0;

    private void Awake()
    {
        hpCurrent = 500;
        hpFull = 500;
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
            hpCurrent -= damage;
        }
        if(temp != totalscore)
        {
            damage = totalscore - temp;
            hpCurrent -= damage;

            temp = totalscore;
        }


        if(bossSlider.value == 0)
        {
            fill.SetActive(false);
        }
    }
}

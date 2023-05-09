using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSlider : MonoBehaviour
{
    public Slider playerSlider;
    public GameObject fill;

    public int hpFull;
    public int hpCurrent;

    float time;

    private void Awake()
    {
        hpCurrent = 100;
        hpFull = 100;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("hpdown", 3f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        playerSlider.value = (float)hpCurrent / hpFull;
    }

    void hpdown()
    {
        hpCurrent -= 5;
    }
}

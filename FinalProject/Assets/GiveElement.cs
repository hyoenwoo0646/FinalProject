using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiveElement : MonoBehaviour
{
    public GameObject whiteBlock; 
    public GameObject redBlock; 
    public GameObject greenBlock; 
    public GameObject blueBlock; 
    public GameObject purpleBlock; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(BlockControl.Instance.whiteblock);
        if(SaveData.whiteblock == true)
        {
            whiteBlock.SetActive(true);
        }
        if(SaveData.redblock == true)
        {
            redBlock.SetActive(true);
        }
        if(SaveData.greenblock == true)
        {
            greenBlock.SetActive(true);
        }
        if(SaveData.blueblock == true)
        {
            blueBlock.SetActive(true);
        }
        if(SaveData.purpleblock == true)
        {
            purpleBlock.SetActive(true);
        }
    }
}

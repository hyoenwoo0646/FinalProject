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
        ElementGiving();
        ElementReact();
    }

    //원소 부여
    void ElementGiving()
    {
        if (SaveData.whiteblock == true)
        {
            whiteBlock.SetActive(true);
        }
        if (SaveData.redblock == true)
        {
            redBlock.SetActive(true);
        }
        if (SaveData.greenblock == true)
        {
            greenBlock.SetActive(true);
        }
        if (SaveData.blueblock == true)
        {
            blueBlock.SetActive(true);
        }
        if (SaveData.purpleblock == true)
        {
            purpleBlock.SetActive(true);
        }
    }

    //원소 반응
    void ElementReact()
    {
        //얼음 반응
        if(SaveData.whiteblock == true)
        {
            //얼음 + 번개 주는 데미지 증가
            if (SaveData.purpleblock == true)
            {
                Debug.Log("데미지 증가");
                FirstBossSlider.Instance.damagePlus = 20;
                Invoke("StopDamagePlus", 5f);

                whiteBlock.SetActive(false);
                purpleBlock.SetActive(false);

                SaveData.whiteblock = false;
                SaveData.purpleblock = false;
            }

            //얼음 + 불 반응 없음
            else if(SaveData.redblock == true)
            {
                whiteBlock.SetActive(false);
                redBlock.SetActive(false);

                SaveData.whiteblock = false;
                SaveData.redblock = false;
            }
            
            //얼음 + 풀 반응 없음
            else if(SaveData.greenblock == true)
            {
                whiteBlock.SetActive(false);
                greenBlock.SetActive(false);

                SaveData.whiteblock = false;
                SaveData.greenblock = false;
            }

            
        }

        //불 반응
        if (SaveData.redblock == true)
        {
            //불 + 풀 추가 데미지
            if (SaveData.greenblock == true)
            {
                FirstBossSlider.Instance.hpCurrent -= 200;
                Debug.Log("추가데미지");

                redBlock.SetActive(false);
                greenBlock.SetActive(false);

                SaveData.redblock = false;
                SaveData.greenblock = false;
            }

            //불 + 번개 반응 없음
            else if(SaveData.purpleblock == true)
            {
                redBlock.SetActive(false);
                purpleBlock.SetActive(false);

                SaveData.redblock = false;
                SaveData.purpleblock = false;
            }

            //불 + 물 반응 없음
            else if(SaveData.blueblock == true)
            {
                redBlock.SetActive(false);
                blueBlock.SetActive(false);

                SaveData.redblock = false;
                SaveData.blueblock = false;
            }
        }

        //번개 반응
        if (SaveData.purpleblock == true)
        {
            //번개 + 물 지속 데미지
            if (SaveData.blueblock == true)
            {
                Debug.Log("지속 데미지");
                InvokeRepeating("dotDamage", 0f, 1f);
                Invoke("StopdotDamage", 5f);

                purpleBlock.SetActive(false);
                blueBlock.SetActive(false);

                SaveData.purpleblock = false;
                SaveData.blueblock = false;
            }

            //번개 + 풀 반응 없음
            else if(SaveData.greenblock == true)
            {
                purpleBlock.SetActive(false);
                greenBlock.SetActive(false);

                SaveData.purpleblock = false;
                SaveData.greenblock = false;
            }
        }

        //물 반응
        if (SaveData.blueblock == true)
        {
            //물 + 얼음 보스 스턴
            if (SaveData.whiteblock == true)
            {
                Debug.Log("보스 스턴");
                SaveData.invokecount = false;

                blueBlock.SetActive(false);
                whiteBlock.SetActive(false);

                SaveData.blueblock = false;
                SaveData.whiteblock = false;
            }
        }

        //풀 반응
        if (SaveData.greenblock == true)
        {
            //풀 + 물 체력 회복
            if (SaveData.blueblock == true)
            {
                Debug.Log("체력 회복");
                PlayerSlider.Instance.hpCurrent += 20;

                greenBlock.SetActive(false);
                blueBlock.SetActive(false);

                SaveData.greenblock = false;
                SaveData.blueblock = false;
            }
        }
    }

    void dotDamage()
    {
        FirstBossSlider.Instance.hpCurrent -= 10;
    }

    void StopdotDamage()
    {
        CancelInvoke("dotDamage");
    }

    void StopDamagePlus()
    {
        FirstBossSlider.Instance.damagePlus = 0;
    }
}

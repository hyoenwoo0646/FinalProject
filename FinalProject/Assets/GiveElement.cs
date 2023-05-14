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

    public GameObject redgreen;
    public GameObject bluewhite;
    public GameObject greenblue;
    public GameObject purpleblue;
    public GameObject whitepurple;

    private static GiveElement instance = null;

    public static GiveElement Instance
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

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }
    }


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
        if (SaveData.whiteblock == true)
        {
            //얼음 + 번개 주는 데미지 증가
            if (SaveData.purpleblock == true)
            {
                if(SaveData.tutorialcount == 1)
                {
                    SaveData.elementReact = true;
                    SaveData.tutorialcount = 2;
                }            
                Debug.Log("데미지 증가");
                if (SaveData.stagecount == 0)
                {
                    FirstBossSlider.Instance.damagePlus = 20;
                }
                else if (SaveData.stagecount == 1)
                {
                    SecondBossSlider.Instance.damagePlus = 20;
                }
                else if (SaveData.stagecount == -1)
                {
                    TutorialBossSlider.Instance.damagePlus = 20;
                }

                WhitePurpleReact();

                whiteBlock.SetActive(false);
                purpleBlock.SetActive(false);

                SaveData.whiteblock = false;
                SaveData.purpleblock = false;
            }

            //얼음 + 불 반응 없음
            else if (SaveData.redblock == true)
            {
                whiteBlock.SetActive(false);
                redBlock.SetActive(false);

                SaveData.whiteblock = false;
                SaveData.redblock = false;
            }

            //얼음 + 풀 반응 없음
            else if (SaveData.greenblock == true)
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
                if (SaveData.tutorialcount == 1)
                {
                    SaveData.elementReact = true;
                    SaveData.tutorialcount = 2;
                }
                if (SaveData.stagecount == 0)
                {
                    FirstBossSlider.Instance.hpCurrent -= 200;
                }
                else if (SaveData.stagecount == 1)
                {
                    SecondBossSlider.Instance.hpCurrent -= 200;
                }
                else if (SaveData.stagecount == -1)
                {
                    TutorialBossSlider.Instance.hpCurrent -= 200;
                }
                Debug.Log("추가데미지");

                RedGreenReact();

                redBlock.SetActive(false);
                greenBlock.SetActive(false);

                SaveData.redblock = false;
                SaveData.greenblock = false;
            }

            //불 + 번개 반응 없음
            else if (SaveData.purpleblock == true)
            {
                redBlock.SetActive(false);
                purpleBlock.SetActive(false);

                SaveData.redblock = false;
                SaveData.purpleblock = false;
            }

            //불 + 물 반응 없음
            else if (SaveData.blueblock == true)
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
                if (SaveData.tutorialcount == 1)
                {
                    SaveData.elementReact = true;
                    SaveData.tutorialcount = 2;
                }

                PurpleBlueReact();

                purpleBlock.SetActive(false);
                blueBlock.SetActive(false);

                SaveData.purpleblock = false;
                SaveData.blueblock = false;
            }

            //번개 + 풀 반응 없음
            else if (SaveData.greenblock == true)
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
                if (SaveData.tutorialcount == 1)
                {
                    SaveData.elementReact = true;
                    SaveData.tutorialcount = 2;
                }

                BlueWhiteReact();

                Debug.Log("보스 스턴");
                PlayerSlider.Instance.stuntime = 6;
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
                if (SaveData.tutorialcount == 1)
                {
                    SaveData.elementReact = true;
                    SaveData.tutorialcount = 2;
                }
                GreenBlueReact();

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
        if (SaveData.stagecount == 0)
        {
            FirstBossSlider.Instance.hpCurrent -= 10;
        }
        else if (SaveData.stagecount == 1)
        {
            SecondBossSlider.Instance.hpCurrent -= 10;
        }
        else if (SaveData.stagecount == -1)
        {
            TutorialBossSlider.Instance.hpCurrent -= 10;
        }
    }

    void StopdotDamage()
    {
        purpleblue.SetActive(false);
        CancelInvoke("dotDamage");
    }

    void StopDamagePlus()
    {
        whitepurple.SetActive(false);
        if (SaveData.stagecount == 0)
        {
            FirstBossSlider.Instance.damagePlus = 0;
        }
        else if (SaveData.stagecount == 1)
        {
            SecondBossSlider.Instance.damagePlus = 0;
        }
        else if (SaveData.stagecount == -1)
        {
            TutorialBossSlider.Instance.damagePlus = 0;
        }
    }

    void RedGreen()
    {
        redgreen.SetActive(false);
    }

    void BlueWhite()
    {
        bluewhite.SetActive(false);
    }

    void GreenBlue()
    {
        greenblue.SetActive(false);
    }

    public void RedGreenReact()
    {
        redgreen.SetActive(true);
        Invoke("RedGreen", 1f);
    }
    
    public void WhitePurpleReact()
    {
        whitepurple.SetActive(true);

        Invoke("StopDamagePlus", 5f);
    }

    public void PurpleBlueReact()
    {
        purpleblue.SetActive(true);
        Debug.Log("지속 데미지");
        InvokeRepeating("dotDamage", 0f, 1f);
        Invoke("StopdotDamage", 5f);
    }

    public void BlueWhiteReact()
    {
        bluewhite.SetActive(true);
        Invoke("BlueWhite", PlayerSlider.Instance.stuntime);
    }

    public void GreenBlueReact()
    {
        greenblue.SetActive(true);
        Invoke("GreenBlue", 1f);
    }
}

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

    //���� �ο�
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

    //���� ����
    void ElementReact()
    {
        //���� ����
        if (SaveData.whiteblock == true)
        {
            //���� + ���� �ִ� ������ ����
            if (SaveData.purpleblock == true)
            {
                if(SaveData.tutorialcount == 1)
                {
                    SaveData.elementReact = true;
                }            
                Debug.Log("������ ����");
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

            //���� + �� ���� ����
            else if (SaveData.redblock == true)
            {
                whiteBlock.SetActive(false);
                redBlock.SetActive(false);

                SaveData.whiteblock = false;
                SaveData.redblock = false;
            }

            //���� + Ǯ ���� ����
            else if (SaveData.greenblock == true)
            {
                whiteBlock.SetActive(false);
                greenBlock.SetActive(false);

                SaveData.whiteblock = false;
                SaveData.greenblock = false;
            }


        }

        //�� ����
        if (SaveData.redblock == true)
        {
            //�� + Ǯ �߰� ������
            if (SaveData.greenblock == true)
            {
                if (SaveData.tutorialcount == 1)
                {
                    SaveData.elementReact = true;
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
                Debug.Log("�߰�������");

                RedGreenReact();

                redBlock.SetActive(false);
                greenBlock.SetActive(false);

                SaveData.redblock = false;
                SaveData.greenblock = false;
            }

            //�� + ���� ���� ����
            else if (SaveData.purpleblock == true)
            {
                redBlock.SetActive(false);
                purpleBlock.SetActive(false);

                SaveData.redblock = false;
                SaveData.purpleblock = false;
            }

            //�� + �� ���� ����
            else if (SaveData.blueblock == true)
            {
                redBlock.SetActive(false);
                blueBlock.SetActive(false);

                SaveData.redblock = false;
                SaveData.blueblock = false;
            }
        }

        //���� ����
        if (SaveData.purpleblock == true)
        {
            //���� + �� ���� ������
            if (SaveData.blueblock == true)
            {
                if (SaveData.tutorialcount == 1)
                {
                    SaveData.elementReact = true;
                }

                PurpleBlueReact();

                purpleBlock.SetActive(false);
                blueBlock.SetActive(false);

                SaveData.purpleblock = false;
                SaveData.blueblock = false;
            }

            //���� + Ǯ ���� ����
            else if (SaveData.greenblock == true)
            {
                purpleBlock.SetActive(false);
                greenBlock.SetActive(false);

                SaveData.purpleblock = false;
                SaveData.greenblock = false;
            }
        }

        //�� ����
        if (SaveData.blueblock == true)
        {
            //�� + ���� ���� ����
            if (SaveData.whiteblock == true)
            {
                if (SaveData.tutorialcount == 1)
                {
                    SaveData.elementReact = true;
                }

                BlueWhiteReact();

                Debug.Log("���� ����");
                PlayerSlider.Instance.stuntime = 6;
                SaveData.invokecount = false;
                

                blueBlock.SetActive(false);
                whiteBlock.SetActive(false);

                SaveData.blueblock = false;
                SaveData.whiteblock = false;
            }
        }

        //Ǯ ����
        if (SaveData.greenblock == true)
        {
            //Ǯ + �� ü�� ȸ��
            if (SaveData.blueblock == true)
            {
                if (SaveData.tutorialcount == 2)
                {
                    SaveData.elementReact = true;
                }
                GreenBlueReact();

                Debug.Log("ü�� ȸ��");
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
        Debug.Log("���� ������");
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

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
        if(SaveData.whiteblock == true)
        {
            //���� + ���� �ִ� ������ ����
            if (SaveData.purpleblock == true)
            {
                Debug.Log("������ ����");
                FirstBossSlider.Instance.damagePlus = 20;
                Invoke("StopDamagePlus", 5f);

                whiteBlock.SetActive(false);
                purpleBlock.SetActive(false);

                SaveData.whiteblock = false;
                SaveData.purpleblock = false;
            }

            //���� + �� ���� ����
            else if(SaveData.redblock == true)
            {
                whiteBlock.SetActive(false);
                redBlock.SetActive(false);

                SaveData.whiteblock = false;
                SaveData.redblock = false;
            }
            
            //���� + Ǯ ���� ����
            else if(SaveData.greenblock == true)
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
                FirstBossSlider.Instance.hpCurrent -= 200;
                Debug.Log("�߰�������");

                redBlock.SetActive(false);
                greenBlock.SetActive(false);

                SaveData.redblock = false;
                SaveData.greenblock = false;
            }

            //�� + ���� ���� ����
            else if(SaveData.purpleblock == true)
            {
                redBlock.SetActive(false);
                purpleBlock.SetActive(false);

                SaveData.redblock = false;
                SaveData.purpleblock = false;
            }

            //�� + �� ���� ����
            else if(SaveData.blueblock == true)
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
                Debug.Log("���� ������");
                InvokeRepeating("dotDamage", 0f, 1f);
                Invoke("StopdotDamage", 5f);

                purpleBlock.SetActive(false);
                blueBlock.SetActive(false);

                SaveData.purpleblock = false;
                SaveData.blueblock = false;
            }

            //���� + Ǯ ���� ����
            else if(SaveData.greenblock == true)
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
                Debug.Log("���� ����");
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

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

    public int plusDamage = 200;
    public int dottDamage = 10;


    public ParticleSystem stun;
    public ParticleSystem plusdamage;
    public ParticleSystem plusdamage1;
    public ParticleSystem plusdamage2;
    public ParticleSystem heal;
    public ParticleSystem wlthr;
    public ParticleSystem damageup;


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

        if(bluewhite.activeSelf == false && stun.isPlaying)
        {
            stun.Stop();
        }
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
                }            
                Debug.Log("데미지 증가");
                if (SaveData.stagecount == 0)
                {
                    FirstBossSlider.Instance.damagePlus = 20;
                }
                else if (SaveData.stagecount == 1)
                {
                    if (SecondBossSlider.Instance.fireshieldSlider.gameObject.activeSelf == true)
                    {
                        SecondBossSlider.Instance.damagePlus = 0;
                    }
                    else if(SecondBossSlider.Instance.fireshieldSlider.gameObject.activeSelf == false)
                    {
                        SecondBossSlider.Instance.damagePlus = 20;
                    }
                }
                else if (SaveData.stagecount == -1)
                {
                    TutorialBossSlider.Instance.damagePlus = 20;
                }
                else if (SaveData.stagecount == 2)
                {
                    if(FinalBossSlider.Instance.fireshieldSlider.gameObject.activeSelf == true || FinalBossSlider.Instance.watershieldSlider.gameObject.activeSelf == true)
                    {
                        FinalBossSlider.Instance.damagePlus = 0;
                    }
                    else if(FinalBossSlider.Instance.fireshieldSlider.gameObject.activeSelf == false && FinalBossSlider.Instance.watershieldSlider.gameObject.activeSelf == false)
                    {
                        FinalBossSlider.Instance.damagePlus = 20;
                    }
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
                }
                if (SaveData.stagecount == 0)
                {
                    FirstBossSlider.Instance.hpCurrent -= plusDamage;
                    DamageText.Instance.CreateDamageText(Camera.main.WorldToScreenPoint(new Vector3(0, 5.5f, 0)), plusDamage);
                }
                else if (SaveData.stagecount == 1)
                {
                    if (SecondBossSlider.Instance.fireshieldSlider.gameObject.activeSelf == true)
                    {
                        SecondBossSlider.Instance.hpCurrent -= 0;
                    }
                    else if (SecondBossSlider.Instance.fireshieldSlider.gameObject.activeSelf == false)
                    {
                        SecondBossSlider.Instance.hpCurrent -= plusDamage;
                        DamageText.Instance.CreateDamageText(Camera.main.WorldToScreenPoint(new Vector3(0, 5.5f, 0)), plusDamage);
                    }         
                }
                else if (SaveData.stagecount == -1)
                {
                    TutorialBossSlider.Instance.hpCurrent -= plusDamage;
                    DamageText.Instance.CreateDamageText(Camera.main.WorldToScreenPoint(new Vector3(0, 5.5f, 0)), plusDamage);
                }
                else if (SaveData.stagecount == 2)
                {
                    if (FinalBossSlider.Instance.fireshieldSlider.gameObject.activeSelf == true || FinalBossSlider.Instance.watershieldSlider.gameObject.activeSelf == true)
                    {
                        FinalBossSlider.Instance.hpCurrent -= 0;
                    }
                    else if (FinalBossSlider.Instance.fireshieldSlider.gameObject.activeSelf == false && FinalBossSlider.Instance.watershieldSlider.gameObject.activeSelf == false)
                    {
                        FinalBossSlider.Instance.hpCurrent -= plusDamage;
                        DamageText.Instance.CreateDamageText(Camera.main.WorldToScreenPoint(new Vector3(0, 5.5f, 0)), plusDamage);
                    }                  
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
                if (SaveData.tutorialcount == 2)
                {
                    SaveData.elementReact = true;
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
            DamageText.Instance.CreateDamageText(Camera.main.WorldToScreenPoint(new Vector3(0, 5.5f, 0)), dottDamage);
        }
        else if (SaveData.stagecount == 1)
        {
            if (SecondBossSlider.Instance.fireshieldSlider.gameObject.activeSelf == true)
            {
                SecondBossSlider.Instance.hpCurrent -= 0;
            }
            else if (SecondBossSlider.Instance.fireshieldSlider.gameObject.activeSelf == false)
            {
                SecondBossSlider.Instance.hpCurrent -= 10;
                DamageText.Instance.CreateDamageText(Camera.main.WorldToScreenPoint(new Vector3(0, 5.5f, 0)), dottDamage);
            }          
        }
        else if (SaveData.stagecount == -1)
        {
            TutorialBossSlider.Instance.hpCurrent -= 10;
            DamageText.Instance.CreateDamageText(Camera.main.WorldToScreenPoint(new Vector3(0, 5.5f, 0)), dottDamage);
        }
        else if (SaveData.stagecount == 2)
        {
            if (FinalBossSlider.Instance.fireshieldSlider.gameObject.activeSelf == true || FinalBossSlider.Instance.watershieldSlider.gameObject.activeSelf == true)
            {
                FinalBossSlider.Instance.hpCurrent -= 0;
            }
            else if (FinalBossSlider.Instance.fireshieldSlider.gameObject.activeSelf == false && FinalBossSlider.Instance.watershieldSlider.gameObject.activeSelf == false)
            {
                FinalBossSlider.Instance.hpCurrent -= 10;
                DamageText.Instance.CreateDamageText(Camera.main.WorldToScreenPoint(new Vector3(0, 5.5f, 0)), dottDamage);
            }
            
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
        else if (SaveData.stagecount == 2)
        {
            FinalBossSlider.Instance.damagePlus = 0;
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
        if (!plusdamage.isPlaying)
        {
            plusdamage.Play();
            plusdamage1.Play();
            plusdamage2.Play();
        }
        Invoke("RedGreen", 1f);
    }
    
    public void WhitePurpleReact()
    {
        whitepurple.SetActive(true);
        SoundManager.Instance.Sword();
        Invoke("StopDamagePlus", 5f);
    }

    public void PurpleBlueReact()
    {
        purpleblue.SetActive(true);
        if (!wlthr.isPlaying)
        {
            wlthr.Play();
 
        }

        Debug.Log("지속 데미지");
        InvokeRepeating("dotDamage", 0f, 1f);
        Invoke("StopdotDamage", 5f);
    }

    public void BlueWhiteReact()
    {
        bluewhite.SetActive(true);
        if (!stun.isPlaying)
        {
            stun.Play();
        }
        Invoke("BlueWhite", PlayerSlider.Instance.stuntime);
    }

    public void GreenBlueReact()
    {
        greenblue.SetActive(true);
        if (!heal.isPlaying)
        {
            heal.Play();
        
        }
        Invoke("GreenBlue", 1f);
    }
}

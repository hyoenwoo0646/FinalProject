using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip title;
    public AudioClip buttonClick;
    public AudioClip backGround;
    public AudioClip breakSound;
    public AudioClip winSound;
    public AudioClip loseSound;
   

    private AudioSource audioSource;

    private static SoundManager instance = null;

    public static SoundManager Instance
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

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Title()
    {
        audioSource.clip = title;
        audioSource.Play();
    }

    public void ButtonSound()
    {
        audioSource.clip = buttonClick;
        audioSource.Play();
    }

    public void Bgm()
    {
        audioSource.clip = backGround;
        audioSource.Play();
    }

    public void BreakSound()
    {
        audioSource.clip = breakSound;
        audioSource.Play();
    }

    public void WinSound()
    {
        audioSource.clip = winSound;
        audioSource.Play();
    }

    public void LoseSound()
    {
        audioSource.clip = loseSound;
        audioSource.Play();
    }
}

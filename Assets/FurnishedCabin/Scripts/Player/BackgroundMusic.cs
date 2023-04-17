using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource bgm;
    public AudioClip livingrmMusic;
    public AudioClip toiletMusic;
    public AudioClip bedroomMusic;

    //Play the music
    bool m_Play;


    void Start()
    {
        //Fetch the AudioSource from the GameObject
        bgm = GetComponent<AudioSource>();
        m_Play = true;
        bgm.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Play == false)
        {
            //Stop the audio
            bgm.Stop();

        }
    }

    public void changeBGM(AudioClip newClip)
    {
        if (bgm.clip != newClip)
        {
            bgm.Stop();
            bgm.clip = newClip;
            bgm.Play();
        }
    }

    public void stopBGM()
    {
        m_Play = false;
    }
}
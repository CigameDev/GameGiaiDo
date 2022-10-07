using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;
    [Range(0,1)]//tao ra 1 cai slider cua bien float ta co the keo de lay gia tri
    public float musicVolume;
    [Range (0,1)]
    public float soundVolume;

    public AudioSource musicAus;//quan ly music 
    public AudioSource soundAus;//quan ly sound

    public AudioClip[] backGroundMusics;
    public AudioClip rightSound;
    public AudioClip loseSound;
    public AudioClip winSound;

    private void Awake()
    {
        MakeSingleton();
    }
    void Start()
    {
        PlayBackgroundMusic();
    }

    private void Update()
    {
        if(musicAus && soundAus)
        {
            //cho phep dieu chinh am luong trong timeline
            musicAus.volume = musicVolume;
            soundAus.volume = soundVolume;

        }    
    }
    public void PlayBackgroundMusic()
    {
        if(musicAus && backGroundMusics !=null && backGroundMusics.Length >0)
        {
            int randIdx = Random.Range(0, backGroundMusics.Length);
            if (backGroundMusics[randIdx] != null)
            {
                musicAus.clip = backGroundMusics[randIdx];
                musicAus.volume = musicVolume;//dieu chinh am luong ngoai inspector
                musicAus.Play();
            }    
        }    
    }    
    public void  StopMusic()//dung nhac nen
    {
        if(musicAus)
        {
            musicAus.Stop();
        }    
    }    
    public void PlaySound(AudioClip sound)
    {
        if(soundAus && sound)
        {
            soundAus.PlayOneShot(sound);
            soundAus.volume = soundVolume;//dieu chinh am luong cua sound
        }    
    }    
    public void PlayRightSound()
    {
        PlaySound(rightSound);
    }    
    public void PlayLoseSound()
    {
        PlaySound(loseSound);
    }    
    public void PlayWinSound()
    {
        PlaySound(winSound);
    }    
    void MakeSingleton()
    {
        if(instance == null)
        {
            instance = this;
        } 
        else
        {
            Destroy(gameObject);
        }    
    }    
}

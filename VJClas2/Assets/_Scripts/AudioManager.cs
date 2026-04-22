using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource bgAudioSource;
    public AudioSource sfxAudioSource;

    public AudioClip jump;
    public AudioClip coin;
    public AudioClip death;
    public AudioClip shoot;
    public AudioClip bullet;

    public Slider bgMusicVolSlider;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        bgMusicVolSlider.value = bgAudioSource.volume;
    }

    public void PlayJump()
    {
        PlaySound(jump);
    }

    public void PlayCoin()
    {
        PlaySound(coin);
    }

    public void PlayDeath()
    {
        PlaySound(death);
    }

    public void PlayShoot()
    {
        PlaySound(shoot);
    }

    public void PlayBullet()
    {
        PlaySound(bullet);
    }

    private void PlaySound(AudioClip clip)
    {
        sfxAudioSource.PlayOneShot(clip);
    }

    public void ChangeVolume()
    {
        bgAudioSource.volume = bgMusicVolSlider.value;
    }
}

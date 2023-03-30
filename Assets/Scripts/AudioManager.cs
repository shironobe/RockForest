using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource[] Sfx;

    public bool muted, mutedSfx;

    public Image Audio, Music;
    public Sprite On, Off;
    public Sprite MusicOn, MusicOff;
    private void Awake()
    {
        

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Start()
    {
        PlaySfx(0);
    }

    // Update is called once per frame
    void Update()
    {

        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                SceneManager.LoadScene(0);

            }
        }

    }

    public void PlaySfx(int Sfxno)
    {
        Sfx[Sfxno].Stop();

        Sfx[Sfxno].Play();
    }

    public void StopMusic()
    {
        if (!muted)
        {
            Sfx[0].Stop();
            muted = true;
            AudioManager.instance.PlaySfx(6);
        }
        else
        {
            Sfx[0].Play();
            muted = false;
            AudioManager.instance.PlaySfx(6);

        }
        updateMusicIcon();
    }

    public void StopSFX()
    {
        if (!mutedSfx)
        {
            Sfx[1].volume = 0;
            Sfx[2].volume = 0;
            Sfx[3].volume = 0;
          Sfx[4].volume = 0;
            Sfx[5].volume = 0;
            Sfx[6].volume = 0;
            mutedSfx = true;
        }
        else
        {
            Sfx[1].volume = 0.3f;
            Sfx[2].volume = 0.3f;
            Sfx[3].volume = 0.3f;
            Sfx[4].volume = 0.3f;
            Sfx[5].volume = 0.5f;
            Sfx[6].volume = 0.3f;
            mutedSfx = false;
            AudioManager.instance.PlaySfx(6);

        }
        updateIcon();
    }
    public void SoundOnOff()
    {

        if (!muted)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            if (muted)
            {
                AudioManager.instance.PlaySfx(5);
                muted = false;
                AudioListener.pause = false;
            }
        }
        //save();
        updateIcon();
    }
    private void updateIcon()
    {
        if (!mutedSfx)
        {
            Audio.sprite = On;

        }
        else
        {
            if (mutedSfx)
            {
                Audio.sprite = Off;
            }

        }
    }
    private void updateMusicIcon()
    {
        if (!muted)
        {
            Music.sprite = MusicOn;

        }
        else
        {
            if (muted)
            {
                Music.sprite = MusicOff;
            }

        }
    }
}

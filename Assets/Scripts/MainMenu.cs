using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using System.Runtime.InteropServices;
public class MainMenu : MonoBehaviour
{
    public int SceneNo;

    public bool muted;

    public Image Audio;
    public Sprite On, Off;

    public Animator SceneTransition;

    public int LevelScreen;

//#if UNITY_WEBGL
   

    //[DllImport("__Internal")]
    //private static extern void StartGameEvent();

   
    //#endif
    void Start()
    {
        SceneTransition = GameObject.FindGameObjectWithTag("FadePanel").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayButton()
    {
        StartCoroutine(LoadLevelScene());
       
       //startevent();

        if (!AudioManager.instance.Sfx[0].isPlaying)
        {
            AudioManager.instance.PlaySfx(0);
        }

    }
    private void startevent()
    {

       // StartGameEvent();

    }

    public void GotoScene()
    {
        StartCoroutine(LoadScene());
    }
   // private static extern void StartGameEvent();
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
                muted = false;
                AudioListener.pause = false;
            }
        }
      //save();
     updateIcon();
    }
    private void updateIcon()
    {
        if (!muted)
        {
            Audio.sprite = On;

        }
        else
        {
            if (muted)
            {
                Audio.sprite = Off;
            }

        }
    }

    IEnumerator LoadScene()
    {
        SceneTransition.SetTrigger("end");
        AudioManager.instance.PlaySfx(6);
        yield return new WaitForSeconds(0.10f);
        SceneManager.LoadScene(SceneNo);
    }

    IEnumerator LoadLevelScene()
    {
        SceneTransition.SetTrigger("end");
        AudioManager.instance.PlaySfx(6);
        yield return new WaitForSeconds(0.10f);
        SceneManager.LoadScene(LevelScreen);
    }
}

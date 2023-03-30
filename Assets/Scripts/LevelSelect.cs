using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using System.Runtime.InteropServices;
public class LevelSelect : MonoBehaviour
{
    public int LevelNo;

    Animator SceneTransition;


////#if UNITY_WEBGL
//    [DllImport("__Internal")]
//    private static extern void StartLevelEvent(int level);
//#endif
    void Start()
    {
        SceneTransition = GameObject.FindGameObjectWithTag("FadePanel").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void GotoLevel()
    {

        StartCoroutine(LoadLevel());
     //   startlevel();
    }
    private void startlevel()
    {

       // StartLevelEvent(LevelNo);

    }
    IEnumerator LoadLevel()
    {

        SceneTransition.SetTrigger("end");
        AudioManager.instance.PlaySfx(6);
        yield return new WaitForSeconds(0.10f);
        SceneManager.LoadScene(LevelNo);
    }



    
}

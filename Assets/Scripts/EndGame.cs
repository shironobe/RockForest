using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    public int SceneNo;
    public Animator SceneTransition;
    void Start()
    {
        SceneTransition = GameObject.FindGameObjectWithTag("FadePanel").GetComponent<Animator>();

        Invoke("PostCredit", 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PostCredit()
    {
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        SceneTransition.SetTrigger("end");
       // AudioManager.instance.PlaySfx(5);
        yield return new WaitForSeconds(0.32f);
        SceneManager.LoadScene(SceneNo);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnlockAllLevels : MonoBehaviour
{
    public static UnlockAllLevels instance;
    

  
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
    private void Start()
    {
       
    }
    public void UnlockAll()
    {

        PlayerPrefs.SetInt("LevelUnlock", 20);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    private void Update()
    {
        
    }
}

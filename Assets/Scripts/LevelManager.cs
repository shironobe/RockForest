using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    int LevelUnlock;
    [SerializeField] Button[] LevelButtons;
    void Start()
    {
        LevelButtons = this.GetComponentsInChildren<Button>();
        if (PlayerPrefs.GetInt("LevelUnlock") == 1)
        {
            PlayerPrefs.SetInt("LevelUnlock", 1);
        }
        LevelUnlock = PlayerPrefs.GetInt("LevelUnlock", 1);

      
        if(LevelUnlock >= 20)
        {
            LevelUnlock = 20;
        }

        for (int i = 0; i < LevelButtons.Length; i++)
        {
       LevelButtons[i].interactable = false;
        }

        for (int i = 0; i < LevelUnlock; i++)
        {
        LevelButtons[i].interactable = true;
        }

        
    }
  
    // Update is called once per frame



}

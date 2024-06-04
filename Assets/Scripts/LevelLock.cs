using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLock : MonoBehaviour
{
    int LevelUnlock;
    [SerializeField] Button[] LevelButtons;
    void Start()
    {

        if (LevelUnlock >= 24)
        {
            LevelUnlock = 23;
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
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MobileMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject[] MobileButtons;

    private void Start()
    {

        if (Application.isMobilePlatform)
        {
            for (int i = 0; i < MobileButtons.Length; i++)
            {
                MobileButtons[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < MobileButtons.Length; i++)
            {
                MobileButtons[i].SetActive(false); ;
            }
        }
        
    }

   
    [DllImport("__Internal")]
    private static extern bool IsMobile();

    public bool isMobile()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
            return IsMobile();
#endif
        return false;
    }
    public void Restart()
    {
        PlayerController.instance.replaylevel();
    }
    
    public void MoveRight()
    {
        PlayerController.instance.MoveRight();
    }

    public void MoveLeft()
    {
        PlayerController.instance.MoveLeft();
    }
    public void MoveUp()
    {
        PlayerController.instance.MoveUp();
    }
    public void MoveDown()
    {
        PlayerController.instance.MoveDown();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanBlock : MonoBehaviour
{
  public  BoxCollider2D block2d;

    public GameObject[] Bans;

    SpriteRenderer sr;

    public Sprite on, off;
    void Start()
    {
    sr=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Bans = GameObject.FindGameObjectsWithTag("Ban");


        foreach (GameObject Ban in Bans)
        {
            
           if(Ban.GetComponent<Ban>().isRock)
            {
                block2d.enabled = false;
                sr.sprite = off;
                
            }
            else
            {
                block2d.enabled = true;
                sr.sprite = on;
                break;
            }
        }


    }


    


}

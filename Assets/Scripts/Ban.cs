using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ban : MonoBehaviour
{
    public bool isRock;
    SpriteRenderer sr;

    public Sprite on, off;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Pushable") || other.CompareTag("Player"))
        {
            isRock = true;
            sr.sprite = on;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pushable") || other.CompareTag("Player"))
        {
            AudioManager.instance.PlaySfx(5);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Pushable") || other.CompareTag("Player"))
        {
            isRock = false;
            sr.sprite = off;
        }
    }



}

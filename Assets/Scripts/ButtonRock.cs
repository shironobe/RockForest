using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRock : MonoBehaviour
{
    public BoxCollider2D ButtonGate2d;
    public SpriteRenderer ButtonGateSr;

    public SpriteRenderer ButtonSr;
    public Sprite ButtonOn, ButtonOff;
    public Sprite ButtonGateOff, ButtongateOn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
       if(other.CompareTag("Player") || other.CompareTag("Pushable"))
       {
            ButtonGate2d.enabled = false;
            ButtonGateSr.sprite = ButtonGateOff;
           // AudioManager.instance.PlaySfx(2);
            ButtonSr.sprite = ButtonOn;

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Pushable"))
        {
            AudioManager.instance.PlaySfx(2);

        }
    }

    private void OnTriggerExit2D(Collider2D other) {

        if (other.CompareTag("Player") || other.CompareTag("Pushable"))
        {
            ButtonGate2d.enabled = true;
            ButtonGateSr.sprite = ButtongateOn;

            ButtonSr.sprite = ButtonOff;
        }
    }
}

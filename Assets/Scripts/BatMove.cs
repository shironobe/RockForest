using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMove : MonoBehaviour
{

    public static BatMove instance;
    public Vector3 destination;

    public float speed;
    public LayerMask BlockMask = 0;
    public float detectionRadius = 1f;

    public bool movingDown;

    public bool isBatMove;

    public GameObject[] Rocks;

    bool shouldMove;

    public GameObject bloodDeathEffect;
  //  private Invoker mInvoker;
    private void Awake()
    {
        instance = this;
    }



    void Start()
    {
        destination = transform.position;

        Rocks = GameObject.FindGameObjectsWithTag("Pushable");

      //  mInvoker = new Invoker();

       
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    }
    void Update()
    {
       // MovingUpDown();
       // if (Vector3.Distance(PlayerController.instance.transform.position, PlayerController.instance.Destination) < Mathf.Epsilon)
        {
           //
           //
           //
           //
           //transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);





            //}
            //foreach (GameObject rock in Rocks)
            //{
            //  if( Vector3.Distance( rock.GetComponent<PushableBlock>().transform.position, rock.GetComponent<PushableBlock>().destination) < Mathf.Epsilon)
            //    {
            //        shouldMove = true;
            //    }
            //    else
            //    {
            //        shouldMove = false;
            //    }
            //}


        }

       
        //if (CheckDirectionUp(Vector3.up))
        //{
        //    movingDown = false;
        //}
        //else
        //{
        //    if (!CheckDirectionUp(Vector3.up))
        //    {
        //        movingDown = true;
        //    }
        //}
    }


   
    public void batMove()
    {
       


        
            if (movingDown)
            {
                if (CheckDirection(Vector3.down) && movingDown)
                {
              // Icommand command = new BatMovementCommand(this.gameObject, Vector3.down);                    // new command pattern on diffrent script
              //CommandInvoker.AddCommand(command);

               destination = transform.position + Vector3.down;

                
                }
            }
            else
            {
                if (CheckDirection(Vector3.up) && !movingDown)
                {
                //Icommand command = new BatMovementCommand(this.gameObject, Vector3.up);
               // CommandInvoker.AddCommand(command);

                  destination = transform.position + Vector3.up;





            }

            }
       
      



    }



    public void UndoBool()
    {
        if (!movingDown)
        {
            movingDown = true;
        }
        else
        {
            //  Icommand command = new BatMovementCommand(this.gameObject, Vector3.up);
                //  CommandInvoker.AddCommand(command);

                movingDown = false;





            

        }
    }
    public void UndobatMove()
    {



        if (!movingDown)
        {
            if (CheckDirection(Vector3.up) && !movingDown)
            {
                //   Icommand command = new BatMovementCommand(this.gameObject, Vector3.down);                     new command pattern on diffrent script
                //  CommandInvoker.AddCommand(command);

                destination = transform.position + Vector3.up;


            }
        }
        else
        {
            if (CheckDirection(Vector3.down) && movingDown)
            {
                //  Icommand command = new BatMovementCommand(this.gameObject, Vector3.up);
                //  CommandInvoker.AddCommand(command);

                destination = transform.position + Vector3.down;





            }

        }





    }

    private bool CheckDirection(Vector3 direction)
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, detectionRadius, BlockMask);
        // Debug.Log(hit);


        // Debug.DrawRay(transform.position, direction);

        // RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);

     //   Debug.DrawRay(transform.position, direction);
      
      if(hit.collider != null)
        {

            if (movingDown)
            {
                movingDown = false;

              //  Icommand command = new BatMovementCommand(this.gameObject, Vector3.up);
               // CommandInvoker.AddCommand(command);
                 destination = transform.position + Vector3.up;


            }
            else
            {
                movingDown = true;

                  destination = transform.position + Vector3.down;
              //  Icommand command = new BatMovementCommand(this.gameObject, Vector3.down);
               // CommandInvoker.AddCommand(command);

            }
           
            return true;
            // string tag = hit.transform.tag;
            //if (hit.collider.gameObject.CompareTag("Pushable"))
            //{
            //    Debug.Log(tag);
            //    Debug.Log(hit);
            //    return false;
            //}

        }

        return true;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")  )
        {
           // Debug.Log("PlayerDed");
        }

        if(other.CompareTag("Pushable") || other.CompareTag("ButtonTrap"))
        {
            AudioManager.instance.PlaySfx(4);
           // Instantiate(bloodDeathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


   

    }

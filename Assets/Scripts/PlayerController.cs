using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    public LayerMask BlockMask = 0;
    public float detectionRadius = 2f;

    public Vector3 Destination;
    public static PlayerController instance;

    public bool canMove;
//#if UNITY_WEBGL
    //[DllImport("__Internal")]
    //private static extern void ReplayEvent(int Level);
    ////#endif


    //[DllImport("__Internal")]
    //private static extern void StartLevelEvent(int level);
    Animator SceneTransition;

    public GameObject mPlayer;
   

    public bool inContact;

    GameObject stopsign;

    public bool isUndoing;
    //  public List<Vector3> lastPos = new List<Vector3>();

    // public int moveplayerNo = 0;
    public SpriteRenderer sr;

    public int Moves;

    public Text noOfMoves;

    public bool isBatMove;

    public GameObject[] Bats;

    public GameObject PlayerDeathEffect;


    public bool isStrong;

    bool isDead;
    private void Awake()
    {
        instance = this;
    }

   
    void Start()
    {
        Destination = transform.position;
        BoxCollider2D box2d = GetComponent<BoxCollider2D>();
        box2d.isTrigger = true;
        canMove = true;
        Bats = GameObject.FindGameObjectsWithTag("Bat");
        SceneTransition = GameObject.FindGameObjectWithTag("FadePanel").GetComponent<Animator>();


        //  stopsign = GameObject.FindGameObjectWithTag("Stop");
        mPlayer = this.gameObject;
        sr = GetComponent<SpriteRenderer>();
        //  noOfMoves = GameObject.FindGameObjectWithTag("EnergyLeft").GetComponent<Text>();
        //  noOfMoves.text = Moves.ToString();


        // Switch to 640 x 480 full-screen
           // Screen.SetResolution(640, 480, true);
        
    }

    // Update is called once per frame

   
    void Update()

    {
       // Screen.SetResolution(320, 180, true);
        // Debug.Log(Vector3.Distance(transform.position, Destination));
        // Debug.Log(Mathf.Epsilon);

        //  if (!Manager.instance.Mobile)
        //  {
        if (!isDead)
        {
            Bats = GameObject.FindGameObjectsWithTag("Bat");
            if (Vector3.Distance(transform.position, Destination) < Mathf.Epsilon /*&& !PushableBlock.instance.isPushed && !PushableBlock.instance.isHooked*/)
            {

                //Debug.Log(Input.GetAxisRaw("Horizontal"));
                //Debug.Log(Input.GetAxisRaw("Vertical"));
                //Debug.Log(CheckDirection(Vector3.right));

                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    sr.flipX = false;
                    isUndoing = false;

                  // if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                   // {
                        if (CheckDirection(Vector3.right))
                        {

                            foreach (GameObject Bat in Bats)
                            {
                                Bat.GetComponent<BatMove>().batMove();
                            }
                           
                           

                           Destination = transform.position + Vector3.right;

                        //    Icommand command = new PlayerMoveCommand(this.gameObject, Vector3.right);
                        //CommandInvoker.AddCommand(command);
                          //  PlayerMovement.PlayerMove(this.gameObject, Vector3.right);        //  Playermove functinality in a diffrent script
                            AudioManager.instance.PlaySfx(1);


                        }
                    //}
                }
                else if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    sr.flipX = true;
                    isUndoing = false;
                  //  if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                   // {
                        if (CheckDirection(Vector3.left))
                        {
                            foreach (GameObject Bat in Bats)
                            {
                                Bat.GetComponent<BatMove>().batMove();
                            }

                            Destination = transform.position + Vector3.left;

                            // Destination = mPlayer.transform.position;

                            //Icommand command = new PlayerMoveCommand(this.gameObject, Vector3.left);
                            //CommandInvoker.AddCommand(command);
                            //  PlayerMovement.PlayerMove(this.gameObject, Vector3.left);
                            AudioManager.instance.PlaySfx(1);


                        }
                  //  }
                }
                else if (Input.GetAxisRaw("Vertical") > 0)
                {
                    isUndoing = false;
                   // if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                   // {

                        if (CheckDirection(Vector3.up))
                        {
                            foreach (GameObject Bat in Bats)
                            {
                                Bat.GetComponent<BatMove>().batMove();
                            }

                            Destination = transform.position + Vector3.up;

                            //Icommand command = new PlayerMoveCommand(this.gameObject, Vector3.up);
                            //CommandInvoker.AddCommand(command);

                            //  PlayerMovement.PlayerMove(this.gameObject, Vector3.up);
                            AudioManager.instance.PlaySfx(1);


                        }
                    //}
                }
                else if (Input.GetAxisRaw("Vertical") < 0)
                {
                    isUndoing = false;
                  //  if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                  // {
                        if (CheckDirection(Vector3.down))
                        {
                            foreach (GameObject Bat in Bats)
                            {
                                Bat.GetComponent<BatMove>().batMove();
                            }

                            Destination = transform.position + Vector3.down;

                            //Icommand command = new PlayerMoveCommand(this.gameObject, Vector3.down);
                            //CommandInvoker.AddCommand(command);

                            // PlayerMovement.PlayerMove(this.gameObject, Vector3.down);
                            AudioManager.instance.PlaySfx(1);


                        }
                   // }
                }

                //}

            }
            else
            {


                transform.position = Vector3.MoveTowards(transform.position, Destination, speed * Time.deltaTime);


            }

        } 
        //}
        if (Input.GetKeyDown(KeyCode.R))
        {
          // replaylevel();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

      
}
    private void replaylevel()
    {

       // ReplayEvent(SceneManager.GetActiveScene().buildIndex);

    }

    //private bool CheckDirection(Vector3 direction)
    //{  

    //    // Debug.DrawRay(transform.position, direction);

    //   .// RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);
    //    if (Physics.Raycast(transform.position, direction, out RaycastHit hit,   detectionRadius, BlockMask))
    //    {
    //        Debug.DrawRay(transform.position, direction);

    //        if (hit.collider.CompareTag("Pushable"))
    //        {

    //            PushableBlock pushableBlock = hit.collider.GetComponent<PushableBlock>();
    //            Debug.Log("BlockFound");

    //            if (!pushableBlock)
    //            {
    //                return false;
    //            }
    //              pushableBlock.Push(direction, speed);


    //        }
    //        return false;
    //    }
    //    return true;
    //}


    public void MovePlayer(Vector3 direction)
    {

        foreach (GameObject Bat in Bats)
        {
            Bat.GetComponent<BatMove>().batMove();
        }


        // Icommand command = new PlayerMoveCommand(this.gameObject, direction);
        //  CommandInvoker.AddCommand(command);

        Destination = transform.position + direction;
        AudioManager.instance.PlaySfx(1);


    }

   

    
    private bool CheckDirection(Vector3 direction) { 
    
    RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, detectionRadius, BlockMask);
       
        Debug.DrawRay(transform.position, direction);

       // RaycastHit2D hit1 = Physics2D.Raycast(hit1pos.transform.position, direction, detectionRadius, BlockMask);
      //  Debug.DrawRay(hit1pos.transform.position, direction);

        if (hit)
        {
           string tag = hit.transform.tag;
          
            if (hit.collider.gameObject.CompareTag("Pushable") )
            {
                PushableBlock pushableBlock = hit.collider.GetComponent<PushableBlock>();

               
                if (!pushableBlock)
                    return false;

                
                pushableBlock.Push(direction, speed);
               // Destination = transform.position + direction;


            }
            return false;
        }
        //if (hit1)
        //{
        //    string tag = hit1.transform.tag;

        //    if (hit1.collider.gameObject.CompareTag("Pushable"))
        //    {
        //        PushableBlock pushableBlock = hit1.collider.GetComponent<PushableBlock>();


        //        if (!pushableBlock)
        //            return false;


        //        pushableBlock.Push(direction, speed);



        //    }
        //    return false;
        //}
     
        return true;
       
    }

    public void Right()
    {
        if (CheckDirection(Vector3.right))
        {
            Destination = transform.position + Vector3.right;
            AudioManager.instance.PlaySfx(1);
        }
    }
    public void Left()
    {
        if (CheckDirection(Vector3.left))
        {
            Destination = transform.position + Vector3.left;
            AudioManager.instance.PlaySfx(1);
        }
    }


    public void Up()
    {
        if (CheckDirection(Vector3.up))
        {
            Destination = transform.position + Vector3.up;
            AudioManager.instance.PlaySfx(1);
        }
    }

    public void Down()
    {

        if (CheckDirection(Vector3.down))
        {
            Destination = transform.position + Vector3.down;
            AudioManager.instance.PlaySfx(1);
        }
    }

    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    inContact = true;
    //    stopsign.SetActive(true);
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    inContact = false;
    //}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
          //  Debug.Log("Level FInished");
           // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

           //  startlevel();

            StartCoroutine(NextLevel());
            if (PlayerPrefs.GetInt("LevelUnlock") < SceneManager.GetActiveScene().buildIndex+1)
            {
                PlayerPrefs.SetInt("LevelUnlock", SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

        if (other.CompareTag("Bat"))
        {
            isDead = true;
            Invoke("RestartLevel", 1f);
            AudioManager.instance.PlaySfx(3);
           Instantiate(PlayerDeathEffect, transform.position, Quaternion.identity);
            transform.localScale = new Vector3(0, 0, 0);
           
        }
    }

    IEnumerator NextLevel()
    {

        SceneTransition.SetTrigger("end");
        // AudioManager.instance.PlaySfx(5);
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void startlevel()
    {

        //StartLevelEvent(SceneManager.GetActiveScene().buildIndex + 1);

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableBlock : MonoBehaviour
{

    public static PushableBlock instance;
    public bool isPushed;
    public bool isHooked;

    public LayerMask BlockMask = 0;
    public float detectionRadius = 1f;

    public Vector3 destination;
    public float _speed ;
    float speedMultiplyer = 1.5f;

    public bool shouldHook;

    public bool isDestroyable;

    Animator anim;

    public GameObject mPlayer;

    private Invoker mInvoker;
    public PushableBlock pushableBlockMagnet;

    public int moveblockNo;

    

    public List<Vector3> lastPos = new List<Vector3>();
    private void Awake()
    {
        instance = this;
        lastPos.Add(transform.position);
    }

    public interface ICommand
    {
        void Execute();
        void ExecuteUndo();
    }
    public class CommandMove : ICommand
    {
        // Start is called before the first frame update
        public CommandMove(GameObject obj, Vector3 direction)
        {
           
            mGameObject = obj;
            mDirection = direction;
           
        }

        public void Execute()
        {

           

            mGameObject.GetComponent<PushableBlock>().destination = mGameObject.transform.position + mDirection;

            mGameObject.GetComponent<PushableBlock>().moveblockNo++;
          //  mGameObject.GetComponent<PushableBlock>().transform.position = mTransform.position;
            // mGameObject.transform.position = Vector3.MoveTowards(mGameObject.transform.position, mGameObject.transform.position + mDirection, 9* Time.deltaTime);
        }

        public void ExecuteUndo()
        {

            //if (mGameObject.GetComponent<PushableBlock>().CheckDirection(-mDirection))
            //{
            // mGameObject.transform.position -= mDirection;
           

              //  int i = mGameObject.GetComponent<PushableBlock>().lastPos.Count;

                mGameObject.GetComponent<PushableBlock>().destination = mGameObject.transform.position - mDirection;

               // mGameObject.GetComponent<PushableBlock>().moveblockNo--;
            
               // mGameObject.GetComponent<PushableBlock>().lastPos.RemoveAt(i - 1);
          

          
            //  mGameObject.GetComponent<PushableBlock>().destination = mGameObject.transform.position - mDirection;

            // mGameObject.GetComponent<PushableBlock>().destination = mTransform.position ;
            //  }
            //  mGameObject.transform.position = mGameObject.transform.position - mDirection;


        }



        GameObject mGameObject;
        Vector3 mDirection;
        Transform mTransform;



    }

    public class Invoker
    {
        public Invoker()
        {
            mCommands = new Stack<ICommand>();
        }

        public void Execute(ICommand command)
        {
            if (command != null)
            {
                mCommands.Push(command);
                mCommands.Peek().Execute();
            }
        }

        public void Undo()
        {
            if (mCommands.Count > 0)
            {
                mCommands.Peek().ExecuteUndo();
                mCommands.Pop();
            }
        }

        Stack<ICommand> mCommands;
    }


    
    void Start()
    {
        destination = transform.position;
        anim = GetComponent<Animator>();
        shouldHook = false;
      

       mInvoker = new Invoker();
        mPlayer = this.gameObject;
       
    }

    // Update is called once per frame
    void Update()
    {
        // if (Vector3.Distance(PlayerController.instance.transform.position, PlayerController.instance.Destination) < Mathf.Epsilon)







        if (Vector3.Distance(transform.position, destination) < Mathf.Epsilon )
            {

          
            transform.position = destination;

              isPushed = false;

              isHooked = false;

          
            PlayerController.instance.canMove = true;
          

        }
            else
            {

          

      
        transform.position = Vector3.MoveTowards(transform.position, destination, _speed * Time.deltaTime);
           

        }
        

        // anim.SetBool("isMoving", isPushed);
    }
    public void Push(Vector3 direction, float speed)
    {
       
        if (!isPushed)
        {
            if (CheckDirection(direction))
            {
                if (Vector3.Distance(PlayerController.instance.transform.position, PlayerController.instance.Destination) < Mathf.Epsilon)
                {
                    // Debug.Log("ImPushed");

                    
                    //Icommand command = new PushRockCommand(this.gameObject, direction);
                    //CommandInvoker.AddCommand(command);
                    destination = transform.position + direction;
                  
                    _speed = speed * speedMultiplyer;
                    isPushed = true;
                    PlayerController.instance.MovePlayer(direction);
                    
                  
                    //  Invoke("Grablastpos", 0f);
                }

               // anim.SetBool("isMoving", isPushed);
            }
            else
            {
               // transform.position = Vector3.MoveTowards(transform.position, destination, _speed * Time.deltaTime);
            }


        }
    }

    private bool CheckDirection(Vector3 direction)
    {

      RaycastHit2D hit = Physics2D.Raycast(transform.position, direction,  detectionRadius, BlockMask);
        // Debug.Log(hit);


        // Debug.DrawRay(transform.position, direction);

        // RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);
        if (hit.collider != null)
        {
            

          //  if (hit.collider.gameObject.CompareTag("Pushable"))
           // {

               
                if (!PlayerController.instance.isStrong)
                {
                    return false;
                }
                else
                {
                    if (PlayerController.instance.isStrong)
                    {

                       PushableBlock pushableBlock = hit.collider.GetComponent<PushableBlock>();


                       if (!pushableBlock)
                       {
                        return false;
                        }


                  
                       pushableBlock.PushAgain(direction, _speed);
                         if (pushableBlock.CheckDirectionAgain(direction)) {
                          Debug.Log("Running");
                       
                           return true;
                    }
                    else
                    {
                        return false;
                    }
                    }

                }
                // string tag = hit.transform.tag;
                //if (hit.collider.gameObject.CompareTag("Pushable"))
                //{
                //    Debug.Log(tag);
                //    Debug.Log(hit);
                //    return false;
                //}

          //  }
        }
        
            return true;
        
       
    }

    public void MoveBlock(Vector3 direction)
    {

        if(CheckDirectionAgain(direction)){

           // Debug.Log("Running");
            destination = transform.position + direction;
        }


    }
    public void PushAgain(Vector3 direction, float speed)
    {

        if (!isPushed)
        {
            if (CheckDirectionAgain(direction))
            {
                if (Vector3.Distance(PlayerController.instance.transform.position, PlayerController.instance.Destination) < Mathf.Epsilon)
                {
                    // Debug.Log("ImPushed");

                    //  ICommand move = new CommandMove(mPlayer, direction);
                    //   mInvoker.Execute(move);
                    //destination = mPlayer.transform.position;

                    destination = transform.position + direction;

                    _speed = speed * speedMultiplyer;
                    isPushed = true;

                   // PlayerController.instance.MovePlayer(direction);
                    //   AudioManager.instance.PlaySfx(6);

                    //  Invoke("Grablastpos", 0f);
                }

                // anim.SetBool("isMoving", isPushed);
            }
            else
            {
                // transform.position = Vector3.MoveTowards(transform.position, destination, _speed * Time.deltaTime);
            }
        }
    }
    private bool CheckDirectionAgain(Vector3 direction)
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, detectionRadius, BlockMask);
        // Debug.Log(hit);


        // Debug.DrawRay(transform.position, direction);

        // RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);
        if (hit.collider != null)
        {


                    return false;
                

            
        }
        return true;

    }

    private bool CheckDirectionForHook(Vector3 direction)
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -direction, detectionRadius, BlockMask);
        // Debug.Log(hit);


      //  Debug.DrawRay(transform.position, -direction);
        if (hit.collider != null)
        {

            if (!PlayerController.instance.isStrong)
            {
                return false;
            }
            else
            {
                if (PlayerController.instance.isStrong)
                {
                    return true;
                }

            }
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



    void Grablastpos()
    {
        lastPos.Add(transform.position);
    }
}

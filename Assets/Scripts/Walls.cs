using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    private bool isPushed;
    public LayerMask BlockMask = 0;
    public float detectionRadius = 1f;

    private Vector3 destination;
    float _speed;
    float speedMultiplyer = 1.5f;

    Animator anim;
    void Start()
    {
        destination = transform.position;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, destination) < Mathf.Epsilon)
        {
            transform.position = destination;
            isPushed = false;

        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, _speed * Time.deltaTime);
        }

       
    }
    public void Push(Vector3 direction, float speed)
    {

        if (!isPushed)
        {
            if (CheckDirection(direction))
            {
                Debug.Log("ImPushed");
                destination = transform.position + direction;
                _speed = speed * speedMultiplyer;
                isPushed = true;
                // anim.SetBool("isMoving", isPushed);
            }
        }
    }

    private bool CheckDirection(Vector3 direction)
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, detectionRadius, BlockMask);
        // Debug.Log(hit);


        Debug.DrawRay(transform.position, direction);
        if (hit.collider != null)
        {
            return false;
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
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 1f;
    public GameObject objectToMove;
    private new Rigidbody2D rigidbody;
    private Animator animator;
    private float h = 0f;
    private float v = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = objectToMove.GetComponent<Rigidbody2D>();
        animator = objectToMove.GetComponent<Animator>();
        h = 1;
        //Vector2 dir = new Vector2(h, v);
        animator.SetInteger("MoveDir", 0);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //float h = Input.GetAxis("Horizontal"); //horizontal axis input
        //float v = Input.GetAxis("Vertical"); //vertical axis input
        // you are using axis names as defined in Edit > Project Settings > Input Manager
        //Debug.Log(h);

        //creates a 2d vector in unity
        Vector2 dir = new Vector2(h, v);
        rigidbody.velocity = dir.normalized * speed;
        //returns the vector with a mag. of 1
        
        //0 = right
        //1 = up
        //2 = down
        //3 = left
    }

    public void ChangeDirUp()
    {
        h = 0;
        v = 1;
        animator.SetInteger("MoveDir", 1);
    }
    public void ChangeDirDown()
    {
        h = 0;
        v = -1;
        animator.SetInteger("MoveDir", 2);
    }
    public void ChangeDirRight()
    {
        h = 1;
        v = 0;
        animator.SetInteger("MoveDir", 0);
    }
    public void ChangeDirLeft()
    {
        h = -1;
        v = 0;
        animator.SetInteger("MoveDir", 3);
    }
}

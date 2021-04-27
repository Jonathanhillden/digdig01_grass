using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_scipt : MonoBehaviour
{
    //Animation
    public Animator animator;
    float horizontalMove;
    //Movement
    public float moveSpeed = 5f;
    public float jump = 5f;
    public bool isGrounded = false;
    public bool onLadder = false;
    bool isClimbing = true;
    float gravity;
    //Camera
    Vector3 offset;
    public Transform camPos;
    //Spawnpoint
    public GameObject spawnpoint;
    // Start is called before the first frame update
    void Start()
    {
        //Camera
        offset = camPos.position - transform.position;
        //Set position till player Spawnpoint
        gameObject.transform.position = spawnpoint.transform.position;
        //Gravity
        gravity = gameObject.GetComponent<Rigidbody2D>().gravityScale;
        //Animation
        horizontalMove = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Ladder();
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        horizontalMove = Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;

        animator.SetFloat("speed", horizontalMove);

        //Camera
        camPos.position = transform.position + offset; 

        if (Input.GetKey("d"))
        {
            //transform.localScale = new Vector2(1, 1);
            //transform.eulerAngles = new Vector3(0, 0, 0);
            animator.SetBool("facingRight", true);
        }

        if (Input.GetKey("a"))
        {
            //transform.localScale = new Vector2(-1, 1);
            //transform.eulerAngles = new Vector3(0, -180, 0);
            animator.SetBool("facingRight", false);

        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
            //Jump Animation
            animator.SetBool("jumping", true);
        }
    }

    void Ladder()
    {
        if (onLadder)
        {
            Vector3 climbing = new Vector3(0f, Input.GetAxis("Vertical"), 0f);
            transform.position += climbing * Time.deltaTime * moveSpeed;

            if (Input.GetKey("w") || Input.GetKey("s"))
            {
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;

                if (!isClimbing)
                {
                    isClimbing = true;
                    //start climbing animation
                    animator.SetBool("climbing", true);
                }
            }
        }
        else
        {
            if (isClimbing)
            {
                if (Input.GetKey("a") || Input.GetKey("d"))
                {
                    isClimbing = false;
                    gameObject.GetComponent<Rigidbody2D>().gravityScale = gravity;
                    //stop climbing animation
                    animator.SetBool("climbing", false);
                }
            }
        }
    }
}

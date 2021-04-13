﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_scipt : MonoBehaviour
{
    //Movement
    public float moveSpeed = 5f;
    public float jump = 5f;
    public bool isGrounded = false;
    public bool onLadder = false;
    bool isClimbing = true;
    //Camera
    Vector3 offset;
    public Transform camPos; 
    // Start is called before the first frame update
    void Start()
    {
        //Camera
        offset = camPos.position - transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        Ladder();
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        //Camera
        camPos.position = transform.position + offset; 

        if (Input.GetKey("d"))
        {
            //transform.localScale = new Vector2(1, 1);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetKey("a"))
        {
            //transform.localScale = new Vector2(-1, 1);
            transform.eulerAngles = new Vector3(0, -180, 0);

        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
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
                    gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                    //stop climbing animation
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleVildsvin : MonoBehaviour
{
    Transform groundCheck;

    public bool isGrounded = true;
    public float idleSpeed = 5f;

    bool idleWalkLeft = true;
    float idleWalkDirectionVariabel = -1f;

    Vector3 groundCheckOffset;

    void Start()
    {
        groundCheck = transform.gameObject.transform.GetChild(0);
        groundCheckOffset.x = groundCheck.position.x - transform.position.x;
        Debug.Log(groundCheckOffset);
    }

    void Update()
    {
        IdleWalk();
        Debug.Log(groundCheck.position);
    }

    void IdleWalk()
    {
        Vector3 movement = new Vector3(idleWalkDirectionVariabel, 0f, 0f);
        transform.position += movement * Time.deltaTime * idleSpeed;

        if (isGrounded == false)
        {
            if (idleWalkLeft == true)
            {
                groundCheck.position -= groundCheckOffset * 2;
                isGrounded = true;
                idleWalkLeft = false;
            }
            else
            {
                groundCheck.position += groundCheckOffset * 2;
                isGrounded = true;
                idleWalkLeft = true;
            }
        }
    }
}

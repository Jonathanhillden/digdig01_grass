using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleVildsvin : MonoBehaviour
{

    public bool isGrounded = true;
    public float idleSpeed = 5f;

    bool idleWalkLeft = true;
    float idleWalkDirectionVariabel = -1f;

    Vector3 groundScale;

    void Start()
    {
        groundScale.x = gameObject.transform.localScale.x;
    }

    void Update()
    {
        IdleWalk();
    }

    void IdleWalk()
    {
        Vector3 movement = new Vector3(idleWalkDirectionVariabel, 0f, 0f);
        transform.position += movement * Time.deltaTime * idleSpeed;

        if (isGrounded == false)
        {
            if (idleWalkLeft == true)
            {
                idleWalkDirectionVariabel = 1f;
                gameObject.transform.localScale -= groundScale * 2;
                isGrounded = true;
                idleWalkLeft = false;
            }
            else
            {
                idleWalkDirectionVariabel = -1f;
                gameObject.transform.localScale += groundScale * 2;
                isGrounded = true;
                idleWalkLeft = true;
            }
        }
    }
}

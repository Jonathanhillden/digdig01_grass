using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderScript : MonoBehaviour
{
    public float moveSpeed = 3f;
    Rigidbody2D spiderRigidbody;
    public Transform groundCheck;
    float nextMoveTime = 0;
    float timesASeacond = 0.5f;
    bool movingDown = false;
    bool movingUp = false; 

    // Start is called before the first frame update
    void Start()
    {
        spiderRigidbody = GetComponent<Rigidbody2D>();
        movingDown = true; 
        //spiderRigidbody.velocity = new Vector2(0f, -1f);
    }

    // Update is called once per frame
    void Update()
    {
        spiderRigidbody.velocity = new Vector2(0f, -moveSpeed); 
        if (Time.time >= nextMoveTime)
        {
            nextMoveTime = Time.time + 1f / timesASeacond;
        }
        if (movingDown)
        {
            spiderRigidbody.velocity = new Vector2(0f, -moveSpeed);
        }
    }

}
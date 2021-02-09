using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_scipt : MonoBehaviour
{
    //Movement
    public float moveSpeed = 5f;
    public float jump = 5f;
    public bool isGrounded = false;
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
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        //Camera
        camPos.position = transform.position + offset; 
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
        }
    }
}

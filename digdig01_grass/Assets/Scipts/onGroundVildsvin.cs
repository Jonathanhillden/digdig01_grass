using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onGroundVildsvin : MonoBehaviour
{
    GameObject vildsvin;
    // Start is called before the first frame update
    void Start()
    {
        vildsvin = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground_Tag")
        {
            vildsvin.GetComponent<idleVildsvin>().isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground_Tag")
        {
            vildsvin.GetComponent<idleVildsvin>().isGrounded = false;
        }
    }
}

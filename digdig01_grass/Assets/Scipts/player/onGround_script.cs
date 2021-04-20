using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onGround_script : MonoBehaviour
{
    public Animator animator;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "ground_Tag")
        {
            Player.GetComponent<player_scipt>().isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground_Tag")
        {
            Player.GetComponent<player_scipt>().isGrounded = false;
            animator.SetBool("jumping", false);
        }
    }
}

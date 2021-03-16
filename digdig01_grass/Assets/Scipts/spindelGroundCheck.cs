using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spindelGroundCheck : MonoBehaviour
{
    GameObject Spider; 
    // Start is called before the first frame update
    void Start()
    {
        Spider = gameObject.transform.parent.gameObject; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Spider.GetComponent<spiderScript>().onTop = true;
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground_tag")
        {
            Spider.GetComponent<spiderScript>().groundCheck = true; 
        }
    }*/
}

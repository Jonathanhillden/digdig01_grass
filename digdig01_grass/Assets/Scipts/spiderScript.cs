using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderScript : MonoBehaviour
{
    public float moveSpeed = 3f;
    Rigidbody2D spiderRigidbody;
    public bool onTop = false;
    public bool onRightWall = false;
    public bool onLeftWall = false;
    public bool Under = false;
    // Start is called before the first frame update
    void Start()
    {
        spiderRigidbody = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        /*if (facingLeft())
        {
            spiderRigidbody.velocity = new Vector2(-moveSpeed, 0f);
        }*/
        Top();
        isUnder();
    }
    /*private bool facingLeft()
    {
        return transform.localScale.x > Mathf.Epsilon; 
    }*/

    private void Top()
    {
        if (onTop == true)
        {
            //transform.Rotate(0f, 90f, 0f); 
            spiderRigidbody.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    private void isUnder()
    {
        
    }
    
    
}
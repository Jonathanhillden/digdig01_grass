using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class venomScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject); 
        if (collision.gameObject.tag.Equals("Player"))
        {

        }
    }
}

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

   
}

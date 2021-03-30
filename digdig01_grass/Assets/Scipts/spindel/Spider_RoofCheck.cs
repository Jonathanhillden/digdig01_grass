using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_RoofCheck : MonoBehaviour
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

    private void OnollisionEnter2D(Collider2D collision)
    {
        Spider.GetComponent<spiderScript>().Under = true;
    }
    /*private void OnTriggerExit2D(Collider2D collision)
    {
        Spider.GetComponent<spiderScript>().Under = false;
    }*/
}

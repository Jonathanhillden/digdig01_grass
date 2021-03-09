using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class chargeVildsvin : MonoBehaviour
{
    public float distance;

    public bool isCharging = false;
    void Start()
    {
        isCharging = false;
        Physics2D.queriesStartInColliders = false;
    }

    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
        if(hitInfo != false)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
        }

        if(hitInfo.collider.CompareTag("Player"))
        {
            if(!isCharging)
            {
                isCharging = true;
                gameObject.GetComponent<idleVildsvin>().speed *= 2;
            }
        }
    }
}

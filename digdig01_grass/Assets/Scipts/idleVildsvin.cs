using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleVildsvin : MonoBehaviour
{
    public float speed;
    public float distance;

    public bool movingRight = true;

    public Transform groundDetection;

    int layerMask;

    void Start()
    {
        layerMask = LayerMask.GetMask("Ground");
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance, layerMask);
        if (!groundInfo.collider)
        {
            if(movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }

            if (gameObject.GetComponent<chargeVildsvin>().isCharging == true)
            {
                gameObject.GetComponent<chargeVildsvin>().isCharging = false;
                speed /= 2;
            }
        }
    }
}

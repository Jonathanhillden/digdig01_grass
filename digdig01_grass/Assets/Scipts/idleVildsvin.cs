using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleVildsvin : MonoBehaviour
{
    public float speed;
    public float groundDetectionRange;
    public float wallDetectionRange;

    public bool movingRight = true;

    public Transform groundCheck;

    int groundLayerMask;
    int wallLayerMask;

    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        groundLayerMask = LayerMask.GetMask("Ground");
        wallLayerMask = LayerMask.GetMask("Wall", "Ground");
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, groundDetectionRange, groundLayerMask);
        RaycastHit2D wallInfo = Physics2D.Raycast(transform.position, transform.right, wallDetectionRange, wallLayerMask);
        if (!groundInfo.collider || wallInfo.collider)
        {
            if (movingRight)
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleVildsvin : MonoBehaviour
{
    public float speed;
    public float groundDetectionRange;
    public float wallDetectionRange;

    public bool movingRight = false;

    public Transform groundCheck;

    int obstacleLayerMask;

    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        obstacleLayerMask = LayerMask.GetMask("Wall", "Ground");
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.right * -speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, groundDetectionRange, obstacleLayerMask);
        RaycastHit2D wallInfo = Physics2D.Raycast(transform.position, transform.right, -wallDetectionRange, obstacleLayerMask);
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
                speed /= 1.5f;
            }
        }
    }
}

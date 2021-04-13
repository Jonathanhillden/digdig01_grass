using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    Rigidbody2D spiderRigidbody;
    float nextMoveTime = 0;
    float timesASeacond = 0.5f;
    bool movingDown = false;
    bool movingUp = false;
    //Shoot
    public float range;
    public Transform target;
    Vector2 direction;
    bool detected = false;

    public GameObject venom;
    public float fireRate;
    private float nextTimeShoot = 0;
    public Transform shootPoint;
    public float force; 

    // Start is called before the first frame update
    void Start()
    {
        spiderRigidbody = GetComponent<Rigidbody2D>();
        movingDown = true;
        Physics2D.queriesStartInColliders = false; 
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = target.position;
        direction = targetPos - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, direction, range);
        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.tag == "Player")
            {
                if (detected == false)
                {
                    detected = true; 
                }
            }
            else
            {
                if (detected == true)
                {
                    detected = false;
                }
            }
        }
        if (detected)
        {
            if (Time.time > nextTimeShoot)
            {
                nextTimeShoot = Time.time + 1 / fireRate;
                Shoot();
            }
        }

        if (movingUp)
        {
            spiderRigidbody.velocity = new Vector2(0f, moveSpeed);
            if (Time.time >= nextMoveTime)
            {
                nextMoveTime = Time.time + 1f / timesASeacond;
                movingUp = false;
                movingDown = true; 
            }
        }
        if (movingDown)
        {
            spiderRigidbody.velocity = new Vector2(0f, -moveSpeed);
            if (Time.time >= nextMoveTime)
            {
                nextMoveTime = Time.time + 1f / timesASeacond;
                movingDown = false;
                movingUp = true; 
            }
        }

        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range); 
    }

    public void Shoot()
    {
        GameObject venomShots = Instantiate(venom, shootPoint.position, Quaternion.identity);
        venomShots.GetComponent<Rigidbody2D>().AddForce(direction * force); 
    }
}
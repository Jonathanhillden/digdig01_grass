using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class venomScript : MonoBehaviour
{
    public int damage = 1;

    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<heathScript>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}

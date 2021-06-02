using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bushes : MonoBehaviour
{
    public int damage = 1;
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        heathScript player = hitInfo.gameObject.GetComponent<heathScript>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
    }
}

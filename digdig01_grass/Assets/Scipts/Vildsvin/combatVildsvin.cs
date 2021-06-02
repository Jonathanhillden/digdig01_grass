using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class combatVildsvin : MonoBehaviour
{
    public int damage = 1;

    private void OnCollisionEnter2D(Collision2D hitInfo)
    {
        heathScript player = hitInfo.gameObject.GetComponent<heathScript>();
        if (player != null)
        {
            player.TakeDamage(damage);

        if (gameObject.GetComponent<idleVildsvin>().movingRight)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            gameObject.GetComponent<idleVildsvin>().movingRight = false;
        }
        else
        {
        transform.eulerAngles = new Vector3(0, 0, 0);
        gameObject.GetComponent<idleVildsvin>().movingRight = true;
        }

        if (gameObject.GetComponent<chargeVildsvin>().isCharging == true)
        {
            gameObject.GetComponent<chargeVildsvin>().isCharging = false;
            gameObject.GetComponent<idleVildsvin>().speed /= 2;
        }
            Physics2D.IgnoreLayerCollision(8, 10, true);
        }
    }
}

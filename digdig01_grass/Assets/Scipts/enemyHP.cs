using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class enemyHP : MonoBehaviour
{
    public int maxHealth = 1;
    private int currentHealth; 
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; 
        //Hurt animation (if more than 1 HP)
        if (currentHealth <= 0)
        {
            Die(); 
        }
    }
    void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(gameObject);
    }
}

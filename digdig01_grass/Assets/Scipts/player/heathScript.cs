using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heathScript : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 3;
    public int currentHealth; 
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; 
    }

    public void TakeDamage (int damage)
    {
        currentHealth -= damage; 

        if (currentHealth <= 0 )
        {
            Die();
        }
        else
        {
            animator.SetTrigger("takeDamage");
        }
    }

    private void Die ()
    {
        animator.SetBool("dead", true);
        Destroy(gameObject); 
    }
}

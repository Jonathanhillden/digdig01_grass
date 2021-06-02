using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class heathScript : MonoBehaviour
{
    float noDamageTimer = 0.1f;
    bool timerIsRunning;

    public Animator animator;
    public int maxHealth = 3;
    public int currentHealth; 
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; 
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (noDamageTimer > 0)
            {
                noDamageTimer -= Time.deltaTime;
            }
            else
            {
                noDamageTimer = 0.1f;
                Physics2D.IgnoreLayerCollision(8, 10, false);
                timerIsRunning = false;
            }
        }
    }

    public void TakeDamage (int damage)
    {
        if (!timerIsRunning)
        {
            timerIsRunning = true;
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                Die();
            }
            else
            {
                animator.SetTrigger("takeDamage");
            }
        }
    }

    private void Die ()
    {
        animator.SetBool("dead", true);
        Destroy(gameObject); 
    }
}

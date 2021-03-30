using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour
{
    public Transform attackArea;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    //Cooldown
    public float attackRate = 2f;
    float nextAttackTime = 0;

    public int attackDamage = 1;
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate; 
            }
        }
    }

    void Attack()
    {
        //Animation
        //Detect enemy in range
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackArea.position, attackRange, enemyLayer); 
        //Apply damage to enemy
        foreach (Collider2D enemy in hitEnemy)
        {
            enemy.GetComponent<enemyHP>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackArea == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackArea.position, attackRange);
    }
}

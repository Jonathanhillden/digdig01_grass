using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class player_testAttack : MonoBehaviour
{
    public bool isAttacking = false;
    public GameObject attackHitbox; 

    // Start is called before the first frame update
    void Start()
    {
        attackHitbox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && isAttacking == false)
        {
            isAttacking = true;

            StartCoroutine(Attack());

            //Invoke("ResetAttack", 0.4f); 
        }
    }

    IEnumerator Attack()
    {
        attackHitbox.SetActive(true); 
        yield return new WaitForSeconds(0.4f);
        attackHitbox.SetActive(false);
        isAttacking = false;
    }

    //void ResetAttack()
    //{
    //isAttacking = false;
    //}
}

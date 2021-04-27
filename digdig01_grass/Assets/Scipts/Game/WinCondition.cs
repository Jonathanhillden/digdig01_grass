using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject WinScreen;

    public void OnTriggerEnter2D(Collider2D hitInfo)
    {
        heathScript player = hitInfo.gameObject.GetComponent<heathScript>();
        if(player != null)
        {
            WinScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        heathScript player = hitInfo.gameObject.GetComponent<heathScript>();
        if(player != null)
        {
            player.gameObject.GetComponent<player_scipt>().onLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D hitInfo)
    {
        heathScript player = hitInfo.gameObject.GetComponent<heathScript>();
        if (player != null)
        {
            player.gameObject.GetComponent<player_scipt>().onLadder = false;
        }

    }
}

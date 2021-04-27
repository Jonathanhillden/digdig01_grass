using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnpointManager : MonoBehaviour
{
    public Transform[] groundSpawnpoints;
    public Transform[] airSpawnpoints;
    public GameObject Vildsvin;
    public GameObject Spindel;
    void Start()
    {
        Debug.Log("Test");
        for (int i = 0; i < groundSpawnpoints.Length; i++)
        {
            Instantiate(Vildsvin, groundSpawnpoints[i].position, groundSpawnpoints[i].rotation);
        }

        for (int i = 0; i < airSpawnpoints.Length; i++)
        {
            Instantiate(Spindel, airSpawnpoints[i].position, airSpawnpoints[i].rotation);
        }
    }
}

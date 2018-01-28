using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNotification : MonoBehaviour
{
    [SerializeField]
    Transform spawnPoint;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            RampManager.instance.SpawnNextRamp(spawnPoint);
    }
}

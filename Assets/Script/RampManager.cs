using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampManager : MonoBehaviour
{
    public static RampManager instance;

    public GameObject[] rampsPrefab;

    public Queue<GameObject> rampObjects = new Queue<GameObject>();

	// Use this for initialization
	void Start ()
    {
        instance = this;	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }	
	}

    public void SpawnNextRamp(Transform spawnPoint)
    {
        int randomIndexer = Random.Range(0, rampsPrefab.Length - 1);
        var nextRamp = Instantiate(rampsPrefab[randomIndexer], spawnPoint.position, Quaternion.Euler(0.0f, 0.0f, 30.0f));
        rampObjects.Enqueue(nextRamp);

       

        if(rampObjects.Count >= 4)
        {
            var firstRamp = rampObjects.Dequeue();
            Destroy(firstRamp.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrnamentScript : MonoBehaviour
{
    public float scoreAmount;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ScoreKeeper.instance.CreatePopUpText(scoreAmount, transform.position);
            ScoreKeeper.instance.AddDecoration();
            AudioManager.audInstance.PlayOrnamentSound();
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presents : OrnamentScript
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ScoreKeeper.instance.CreatePopUpText(scoreAmount, transform.position);
            ScoreKeeper.instance.AddPresent();
            AudioManager.audInstance.PlayPresentSound();
            Destroy(gameObject);
        }
    }
}

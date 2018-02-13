using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHitScript : MonoBehaviour
{
    
    public void OnCollisionEnter(Collision col)
    {
        if (col.collider.name.Contains("Tree"))
        {
            print("I hit a tree!");
            AudioManager.audInstance.PlayTreeHitSound();
        }
    }
}

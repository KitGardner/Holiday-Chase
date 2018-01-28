using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform target;

    private Vector3 offset;
	// Use this for initialization
	void Start ()
    {
        offset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }
	}
}

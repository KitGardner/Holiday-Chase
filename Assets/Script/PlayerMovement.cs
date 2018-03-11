using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    float movementForce;
    [SerializeField]
    float sideMovementForce;
    [SerializeField]
    float impactMagnitude;

    private Vector3 direction;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        direction = new Vector3(vertical * movementForce, -movementForce, -horizontal * sideMovementForce);

        rb.AddForce(direction);
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.collider.name.Contains("Rock"))
        {
            rb.AddForce(-direction * impactMagnitude);
        }
    }
}

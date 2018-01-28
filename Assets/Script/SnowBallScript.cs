using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallScript : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    float movementForce;
    [SerializeField]
    Vector3 ballRotation;

    private Vector3 direction;

    private Vector3 baseScale;
    private Vector3 newScale;
    private const float growthScale = 1.25f;

    private float growthTimer;

    

	// Use this for initialization
	void Start ()
    {
        growthTimer = 0.0f;
        rb = GetComponent<Rigidbody>();
        baseScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(growthTimer < 20.0f)
        {
            growthTimer += Time.deltaTime;

            newScale = baseScale + new Vector3(growthTimer * growthScale, growthTimer * growthScale, growthTimer * growthScale);

            transform.localScale = newScale;
        }

        direction = new Vector3(-movementForce, -movementForce, 0.0f);

        rb.AddForce(direction, ForceMode.Force);
        transform.Rotate(ballRotation);
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(other.gameObject);
            AudioManager.audInstance.PlayDeathSound();
            ScoreKeeper.instance.TurnOnEndPanel();
        }
    }
}

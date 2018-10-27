using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveVelocity;

    Rigidbody thisRB;

	// Use this for initialization
	void Start ()
    {
        thisRB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        thisRB.AddForce(
            horizontalInput * moveVelocity, 
            0f,
            verticalInput * moveVelocity,
            ForceMode.Force
        );
    }
}

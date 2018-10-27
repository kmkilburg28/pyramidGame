using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveVelocity;

    Rigidbody thisRB;

    Vector3 rbTurnVelocity;
    Vector3 mousePosition;

	// Use this for initialization
	void Start ()
    {
        thisRB = GetComponent<Rigidbody>();
        rbTurnVelocity = new Vector3(0, 1, 0);
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

        mousePosition = Input.mousePosition;
        mousePosition.x -= Screen.width / 2;
        float intensityX = (mousePosition.x / (Screen.width / 2));

        Quaternion deltaRotation = Quaternion.Euler(rbTurnVelocity * intensityX);
        thisRB.MoveRotation(thisRB.rotation * deltaRotation);
    }
}

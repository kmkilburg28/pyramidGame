using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovement : MonoBehaviour {

    public float moveVelocity;

    public float maxVelocity;

    Rigidbody thisRB;

    GameObject head;

    // Use this for initialization
    void Start () {
        thisRB = GetComponent<Rigidbody>();
        head = GameObject.Find("Head");
    }
	
	// Update is called once per frame
	void Update () {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 velocity = thisRB.velocity;
        float velocityMag = (velocity.x + velocity.z) / 2;

        transform.eulerAngles = new Vector3(0.0f, head.transform.eulerAngles.y, 0.0f);

        if (Mathf.Abs(velocityMag) < maxVelocity)
            thisRB.AddRelativeForce(
                horizontalInput * moveVelocity,
                0f,
                verticalInput * moveVelocity,
                ForceMode.Force
            );
	}
}

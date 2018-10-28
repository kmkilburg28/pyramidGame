using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolveCamera : MonoBehaviour {

    public float rotateSpeed;

    GameObject rotationPoint;

    // Use this for initialization
	void Start ()
    {
        rotationPoint = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.RotateAround(rotationPoint.transform.position, Vector3.up, rotateSpeed * Time.fixedDeltaTime);
    }
}

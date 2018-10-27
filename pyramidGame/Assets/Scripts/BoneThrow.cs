using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneThrow : MonoBehaviour {

    public float upSpeed;

    public float chargeSpeed;
    
    Transform startRotation;

    Transform uprightRotation;

    Transform endRotation;

    Transform endBackTiltRotation;

    private bool liftingUp;
    private bool charging;

    // Use this for initialization
    void Start ()
    {
        startRotation = GameObject.Find("ThrowArmBoneStart").GetComponent<Transform>();
        uprightRotation = GameObject.Find("ThrowArmBoneUpright").GetComponent<Transform>();
        endRotation = GameObject.Find("ThrowArmBoneEnd").GetComponent<Transform>();
        endBackTiltRotation = GameObject.Find("ThrowArmBoneEndBackTilt").GetComponent<Transform>();
        liftingUp = true;
        charging = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (liftingUp)
        {
            float step = upSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation,
                                                          uprightRotation.rotation, step);
        }
        else if (charging)
        {
            float step = chargeSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, endRotation.rotation, step);
        }
        else
        {
            Debug.Log("Back Tilting");
            float step = chargeSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, endBackTiltRotation.rotation, step);
        }
        if (transform.rotation == uprightRotation.rotation)
        {
            liftingUp = false;
            charging = true;
        }
        else if (transform.rotation == endRotation.rotation)
        {
            Debug.Log("Stop charging");
            charging = false;
        }
        if (transform.rotation == endBackTiltRotation.rotation)
        {
            Debug.Log("Return to charging");
            charging = true;
        }
    }
}

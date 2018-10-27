using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneThrow : MonoBehaviour {

    public float upSpeed;

    public float chargeSpeed;

    public float launchForce;

    public float spinForce;
    
    Transform startRotation;

    Transform uprightRotation;

    Transform endRotation;

    Transform endBackTiltRotation;

    GManager GManager;

    Rigidbody thisRB;

    private bool liftingUp;
    private bool charging;
    private bool charged;

    // Use this for initialization
    void Start ()
    {
        startRotation = GameObject.Find("ThrowArmBoneStart").GetComponent<Transform>();
        uprightRotation = GameObject.Find("ThrowArmBoneUpright").GetComponent<Transform>();
        endRotation = GameObject.Find("ThrowArmBoneEnd").GetComponent<Transform>();
        endBackTiltRotation = GameObject.Find("ThrowArmBoneEndBackTilt").GetComponent<Transform>();
        liftingUp = true;
        charging = false;
        GManager = GameObject.Find("GManager").GetComponent<GManager>();
        thisRB = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.parent != null)
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
                float step = chargeSpeed * Time.deltaTime;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, endBackTiltRotation.rotation, step);
            }
            if (transform.rotation == uprightRotation.rotation)
            {
                liftingUp = false;
                charging = true;
                charged = true;
            }
            else if (transform.rotation == endRotation.rotation)
            {
                charging = false;
            }
            if (transform.rotation == endBackTiltRotation.rotation)
            {
                charging = true;
            }

            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                if (!charged)
                {
                    GManager.numBones++;
                    Destroy(this.gameObject);
                }
                else
                {
                    transform.parent = null;
                    thisRB.isKinematic = false;
                    thisRB.AddRelativeForce(
                        launchForce,
                        0f,
                        0f,
                        ForceMode.Impulse
                    );
                    thisRB.AddRelativeTorque(Vector3.up * -spinForce, ForceMode.Impulse);
                }
            }
        }
    }
}

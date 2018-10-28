using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneHit : MonoBehaviour {

    public float attackSpeed;

    Transform startHitRotation;

    Transform endHitRotation;

    private bool attacking;
    private bool halfway;

	// Use this for initialization
	void Start ()
    {
        startHitRotation = GameObject.Find("HitArmBoneStart").GetComponent<Transform>();
        endHitRotation = GameObject.Find("HitArmBoneEnd").GetComponent<Transform>();
        attacking = false;
        halfway = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (attacking)
        {
            if (!halfway)
            {
                float step = attackSpeed * Time.deltaTime;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, endHitRotation.rotation, step);
            }
            else
            {
                float step = attackSpeed * Time.deltaTime;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, startHitRotation.rotation, step);

            }
        }
        if (transform.rotation == endHitRotation.rotation)
        {
            halfway = true;
        }
        else if (transform.rotation == startHitRotation.rotation)
        {
            attacking = false;
            halfway = false;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            attacking = true;
        }
    }
}

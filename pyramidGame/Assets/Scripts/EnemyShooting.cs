﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {


    public Transform tr_Player;
    public GameObject projectile;

    public float maximumLookDistance = 30;
    public float maximumAttackDistance = 10;
    public float minimumDistanceFromPlayer = 2;
    public float f_RotSpeed;

    public float rotationDamping =2f;
    public float shotInterval = 0.5f;
    public float shotTime = 0;
    public float shootForce;

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update () {
        var distance = Vector3.Distance(tr_Player.position, transform.position);

        if (distance <= maximumLookDistance)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(tr_Player.position - transform.position), f_RotSpeed * Time.deltaTime);
            if (distance <= maximumAttackDistance && (Time.time - shotTime) > shotInterval)
            {
                
                shotTime = Time.time;
                //bullet = Instantiate(bullet, transform.position, transform.rotation);
                GameObject bullet = Instantiate(projectile, transform.position + (tr_Player.position - transform.position).normalized, Quaternion.LookRotation(tr_Player.position - transform.position));

                Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();

                bulletRB.AddRelativeForce(
                    0f,
                    0f,
                    shootForce,
                    ForceMode.Impulse
                );
            }
        }

    }
}

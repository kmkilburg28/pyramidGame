using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampMov : MonoBehaviour {
    GManager GManager;
    //Transform startRotation;
    Transform endRotation;


    // Use this for initialization
    void Start () {
        GManager = GameObject.Find("GManager").GetComponent<GManager>();
        //startRotation = GameObject.Find("ramp").GetComponent<Transform>();
        endRotation = GameObject.Find("EndRamp").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        if (GManager.numEnemies <= 0)
        {
            GameObject.Find("ramp").GetComponent<GameObject>();
    
            transform.rotation = Quaternion.RotateTowards(transform.rotation, endRotation.rotation, 2);
        }
    }
}

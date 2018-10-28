using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour {
    GManager GManager;
    // Use this for initialization
    void Start () {
        GManager = GameObject.Find("GManager").GetComponent<GManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            
            GManager.numBones--;

        }
    }
}

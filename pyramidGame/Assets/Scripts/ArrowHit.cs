using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHit : MonoBehaviour {
    GManager GManager;
    public float damageVelocity;
   
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

            if (GetComponent<Rigidbody>().velocity.x >= damageVelocity)
            {
                GManager.numBones--;
            }
            else if (GetComponent<Rigidbody>().velocity.y >= damageVelocity)
            {
                GManager.numBones--;
            }
            else if (GetComponent<Rigidbody>().velocity.z >= damageVelocity)
            {
                GManager.numBones--;
            }

        }
        if (other.gameObject.CompareTag("floor"))
        {
            Destroy(gameObject);
        }
    }
}

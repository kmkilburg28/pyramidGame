using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObj : MonoBehaviour {

    public GameObject destroyedVersion;
    GManager GManager;


      void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bone"))
        {
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            GManager.numEnemies--;
            Destroy(transform.parent.gameObject);
        } 
    }



   
    // Use this for initialization
    void Start () {
        GManager = GameObject.Find("GManager").GetComponent<GManager>();
        GManager.numBones++;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

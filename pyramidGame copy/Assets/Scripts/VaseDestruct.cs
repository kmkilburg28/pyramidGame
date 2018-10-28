using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseDestruct : MonoBehaviour {

    public GameObject destroyedVersion;

    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bone"))
        {
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

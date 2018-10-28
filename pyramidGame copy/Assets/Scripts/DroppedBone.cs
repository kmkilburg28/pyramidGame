using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedBone : MonoBehaviour {

    GManager GManager;

	// Use this for initialization
	void Start ()
    {
        GManager = GameObject.Find("GManager").GetComponent<GManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            GManager.AddText("[R] Pick up bone");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                GManager.numBones++;
                GManager.AddText("");
                Destroy(this.gameObject);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            GManager.AddText("");
        }
    }
}

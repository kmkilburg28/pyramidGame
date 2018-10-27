using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0f, 90f, 0f));
        
    }
}

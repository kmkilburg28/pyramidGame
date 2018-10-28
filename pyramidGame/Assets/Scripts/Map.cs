using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Renderer rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("_Color");
        rend.material.SetColor("_Color", Color.green);

    }

    // Update is called once per frame
    void Update () {
		
	}
}

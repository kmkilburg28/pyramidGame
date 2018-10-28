using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {
    GManager GManager;
    int bonesLeft;

	// Use this for initialization
	void Start () {
        GManager = GameObject.Find("GManager").GetComponent<GManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            bonesLeft = GManager.numBones;
            PlayerPrefs.SetInt("Player Score", bonesLeft );
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

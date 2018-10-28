using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour {

    GManager GManager;

    private bool isInside;

    IEnumerator thisCoroutine;

    // Use this for initialization
    void Start () {
        GManager = GameObject.Find("GManager").GetComponent<GManager>();
        isInside = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            
            if (!isInside)
            {
                thisCoroutine = InsidePlayer();
                StartCoroutine(thisCoroutine);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            isInside = false;
        }
    }

    IEnumerator InsidePlayer()
    {
        while (isInside)
        {
            GManager.numBones--;
            yield return new WaitForSeconds(1);
        }
        if (!isInside)
        {
            StopCoroutine(thisCoroutine);
            yield return null;
        }
    }
}

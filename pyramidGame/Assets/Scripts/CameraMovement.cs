using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Vector3 mousePosition;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        mousePosition = Input.mousePosition;
        mousePosition.x += Screen.width / 2;
        mousePosition.y += Screen.height / 2;
        mousePosition.z = transform.position.z;
        Quaternion rotation = Quaternion.Euler(0, FindAngle(), 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 1);
        Debug.Log(mousePosition);
        Debug.Log(Screen.width / 2);
        Debug.Log(Screen.height / 2);
    }



    private float FindAngle()
    {
        float angle;
        float distanceX = mousePosition.x - Screen.width / 2;
        float distanceY = mousePosition.y - Screen.height / 2;
        angle = Mathf.Rad2Deg * Mathf.Atan(distanceY / distanceX);
        if (mousePosition.x < transform.position.x)
        {
            angle -= 180;
        }
        return angle + -90;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Vector3 mousePosition;

    Vector3 shiftVelocity;

    // Use this for initialization
    void Start ()
    {
        shiftVelocity = new Vector3(0f, 1f, 0f);
    }
	
	// Update is called once per frame
	void Update ()
    {

        mousePosition = Input.mousePosition;
        mousePosition.x -= Screen.width / 2;
        mousePosition.y -= Screen.height / 2;
        mousePosition.z = transform.position.z;

        float intensityY = Mathf.Abs(mousePosition.y / (Screen.height / 2));
        Debug.Log(intensityY);

        Quaternion direction = new Quaternion();
        // Get new direction
        direction = Quaternion.Euler(new Vector3(mousePosition.y, 0f, 0f));
        transform.rotation = Quaternion.RotateTowards(transform.rotation,
                                                      direction, intensityY);

    }

}

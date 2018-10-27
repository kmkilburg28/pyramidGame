using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Vector3 mousePosition;

    GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {

        mousePosition = Input.mousePosition;
        mousePosition.x -= Screen.width / 2;
        mousePosition.y -= Screen.height / 2;
        mousePosition.z = transform.position.z;

        float intensityX = Mathf.Abs(mousePosition.x / (Screen.width / 2));
        float intensityY = Mathf.Abs(mousePosition.y / (Screen.height / 2));
        Debug.Log(intensityX);
        Debug.Log(intensityY);


        Quaternion direction = new Quaternion();
        // Get new direction
        direction.SetLookRotation(new Vector3(0f, mousePosition.y, 0f));
        transform.rotation = Quaternion.RotateTowards(transform.rotation,
                                                      direction, intensityY);

    }



    private float FindAngle(float position)
    {
        float angle;
        float distanceX = mousePosition.x - transform.position.x;
        float distanceY = mousePosition.y - transform.position.y;
        angle = Mathf.Rad2Deg * Mathf.Atan(distanceY / distanceX);

        return angle;
    }

}

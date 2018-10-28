using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovement : MonoBehaviour
{

    public float degreeOfRotation;

    GameObject body;

    Vector3 mousePosition;

    public float speedH = 1.0f;
    public float speedV = 1.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    public float stillWindowSize;


    // Use this for initialization
    void Start()
    {
        body = GameObject.Find("Body");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(body.transform.position.x, body.transform.position.y+body.transform.localScale.y/1.1f, body.transform.position.z);


        mousePosition = Input.mousePosition;
        mousePosition.x -= Screen.width / 2;
        mousePosition.y -= Screen.height / 2;
        float intensityX = (mousePosition.x / (Screen.width / 2));
        float intensityY = (mousePosition.y / (Screen.height / 2));

        if (Mathf.Abs(intensityX) < stillWindowSize)
        {
            intensityX = 0;
        }
        else if (intensityX < 0)
        {
            intensityX = ((mousePosition.x + stillWindowSize) / (Screen.width / 2));
        }
        else
        {
            intensityX = ((mousePosition.x - stillWindowSize) / (Screen.width / 2));
        }
        if (Mathf.Abs(intensityY) < stillWindowSize)
        {
            intensityY = 0;
        }
        else if (intensityY < 0)
        {
            intensityX = ((mousePosition.x + stillWindowSize) / (Screen.width / 2));
        }
        else
        {
            intensityX = ((mousePosition.x - stillWindowSize) / (Screen.width / 2));
        }

        yaw += speedH * intensityX;
        pitch -= speedV * intensityY;

        if (-degreeOfRotation < pitch && pitch < degreeOfRotation)
        {
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
        else
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yaw, 0.0f);
            pitch += speedV * intensityY;
        }
    }
}

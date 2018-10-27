using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovement : MonoBehaviour {

    public float beginningVelocity;

    private float moveVelocity;

    public float maxVelocity;

    public float jumpForce;

    private bool grounded;

    private float horizontalInput;

    private float verticalInput;

    private float yVelocity;

    public float gravity;

    Rigidbody thisRB;

    GameObject head;

    // Use this for initialization
    void Start () {
        thisRB = GetComponent<Rigidbody>();
        head = GameObject.Find("Head");
    }
	
	// Update is called once per frame
	void Update () {

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");



        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            /*thisRB.AddForce(
                0f,
                jumpForce,
                0f,
                ForceMode.Impulse
            );*/
            yVelocity = jumpForce;
        }

    }

    void FixedUpdate()
    {
        Vector3 velocity = thisRB.velocity;
        float velocityMag = (velocity.x + velocity.z) / 2;

        transform.eulerAngles = new Vector3(0.0f, head.transform.eulerAngles.y, 0.0f);
       

        if ((horizontalInput > 0 || verticalInput > 0) && moveVelocity < maxVelocity)
        {
            moveVelocity += Time.fixedDeltaTime;
        }
        else if (horizontalInput == 0 && verticalInput == 0)
        {
            moveVelocity = beginningVelocity;
        }

        Vector3 movement = new Vector3(horizontalInput * moveVelocity * Time.fixedDeltaTime,
                                       yVelocity * Time.fixedDeltaTime,
                                       verticalInput * moveVelocity * Time.fixedDeltaTime);

        movement = transform.TransformDirection(movement) + transform.position;

        thisRB.MovePosition(movement);
        if (!grounded)
        {
            yVelocity -= gravity * Time.fixedDeltaTime;
        }

        Collider[] beneath = Physics.OverlapBox(
           // Center point of search box
            new Vector3(transform.position.x, transform.position.y, transform.position.z),

           // Width and height of search area
            new Vector3(transform.localScale.x - 0.1f, transform.localScale.y, transform.localScale.z),

           // Z rotation
            transform.localRotation);

        grounded = false;
        foreach (Collider c in beneath)
        {
            if (c.gameObject.CompareTag("floor"))
            {
                grounded = true;
            }
        }

    }
}

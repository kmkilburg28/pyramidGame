using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour {
   
    private float level;
    GameObject level0;
    GameObject level1;
    GameObject level2;
    GameObject level3;
    GameObject level4;
    public float rotateSpeed;

    GameObject rotationPoint;

    // Use this for initialization
    void Start () {
        rotationPoint = transform.gameObject;
        level0 = gameObject.transform.Find("Level0").gameObject;
        level1 = gameObject.transform.Find("Level1").gameObject;
        level2 = gameObject.transform.Find("Level2").gameObject;
        level3 = gameObject.transform.Find("Level3").gameObject;
        level4 = gameObject.transform.Find("Level4").gameObject;

        level = SceneManager.GetActiveScene().buildIndex;

        if (level == 1)
        {
            level0.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
        else if (level == 2)
        {
            level1.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
        else if (level == 3)
        {
            level2.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
        else if (level == 4)
        {
            level3.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
        else if (level == 5)
        {
            level4.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
        else if(level == 6)
        {
            level0.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            level1.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            level2.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            level3.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            level4.GetComponent<Renderer>().material.SetColor("_Color", Color.green);

        }


       

    }

    // Update is called once per frame
    void Update () {
       

    }
    private void FixedUpdate()
    {
        transform.RotateAround(rotationPoint.transform.position, Vector3.up, rotateSpeed * Time.fixedDeltaTime);
    }
}

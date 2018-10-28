using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyFollow : MonoBehaviour { 
    Transform tr_Player;
    public float f_RotSpeed, f_MoveSpeed;
    public float minimumDistance;
       

        // Use this for initialization\r
        void Start()
    {
       
        tr_Player = GameObject.FindGameObjectWithTag("player").transform;
    }

    // Update is called once per frame\r
    void Update()
    {
        var distance = Vector3.Distance(tr_Player.position, transform.position);

        /* Look at Player*/
        if (distance <= minimumDistance)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(tr_Player.position - transform.position), f_RotSpeed * Time.deltaTime);
            transform.position += transform.forward * f_MoveSpeed * Time.deltaTime;
        }
        /* Move at Player*/
    
   

    }
    
}
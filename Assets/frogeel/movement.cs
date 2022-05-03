using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class movement : MonoBehaviour
{

    Rigidbody rb;
    private int MoveSpeed = 10;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Input.GetAxisRaw("Horizontal"); { this.rb.position +=  * MoveSpeed * Time.deltaTime; }
    }
}

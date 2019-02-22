using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.UpArrow)){
            rb.AddForce(transform.forward);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(-transform.forward);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddTorque(0,-0.015f,0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddTorque(0, 0.015f, 0);
        }
    }
}

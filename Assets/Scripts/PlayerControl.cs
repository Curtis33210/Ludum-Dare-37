using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 _forward = new Vector3(0, 0, 1 );
        Vector3 _backward = new Vector3(0, 0, -1);
        Vector3 _left = new Vector3(-1, 0, 0);
        Vector3 _right = new Vector3(1, 0, 0);
        if ((Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.UpArrow))))
        {
            rb.AddForce(_forward * 10);
        }
        else if ((Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.DownArrow)))
        {
            rb.AddForce(_backward * 10);
        }
        else if ((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            rb.AddForce(_left * 10);
        }
        else if ((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow)))
        {
            rb.AddForce(_right * 10);
        }
    }
}
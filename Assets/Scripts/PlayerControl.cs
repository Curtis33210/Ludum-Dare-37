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
        Vector3 _forward = transform.forward;
        Vector3 _backward = -transform.forward;
        Vector3 _left = -transform.right;
        Vector3 _right = transform.right;
        Vector3 _final = new Vector3(0, 0, 0);
        if ((Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.UpArrow))))
        {
            _final += _forward;
        }
        if ((Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.DownArrow)))
        {
            _final += _backward;
        }
        if ((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            _final += _left;
        }
        if ((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow)))
        {
            _final += _right;
        }
        _final = new Vector3(_final.x, 0, _final.z);
        _final.Normalize();
        rb.MovePosition((transform.position + _final*.2f));
    }
}
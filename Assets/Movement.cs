using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Rigidbody rb;
    Transform transform;
    [SerializeField] float jumpForce;
    [SerializeField] float moveForce;
    private bool grounded;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
        grounded = false;
    }

    void Update()
    {
        if (rb.IsSleeping())
            transform.localScale = new Vector3(2, 2, 2);

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            transform.localScale = new Vector3(1, 1, 1);
            rb.AddForce(Vector3.up * jumpForce * Time.deltaTime, ForceMode.Impulse);
        }


        if (Input.GetKey(KeyCode.W))
        {
            transform.localScale = new Vector3(1, 1, 1);
            rb.AddForceAtPosition(Vector3.forward * moveForce * Time.deltaTime, rb.position + new Vector3(0, 1, 0), ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localScale = new Vector3(1, 1, 1);
            rb.AddForceAtPosition(Vector3.back * moveForce * Time.deltaTime, rb.position + new Vector3(0, 1, 0), ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(1, 1, 1);
            rb.AddForce(Vector3.right * moveForce * Time.deltaTime, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(1, 1, 1);
            rb.AddForce(Vector3.left * moveForce * Time.deltaTime, ForceMode.Acceleration);
        }

        if (Input.GetKey(KeyCode.Q))
            rb.AddTorque(Vector3.down * moveForce / 4);
        if (Input.GetKey(KeyCode.E))
            rb.AddTorque(Vector3.up * moveForce / 4);
    }

    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }

    private void OnCollisionStay(Collision collision)
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody characterRB;
    //Transform characterTransform;
    Vector3 movementInput;
    Vector3 movementVector;
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpForce;

    private float sprint = 1;
    private bool grounded = true;


    void Start()
    {
        characterRB = GetComponent<Rigidbody>();    
        //characterTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        movementVector = transform.forward * movementInput.y + transform.right * movementInput.x;
        movementVector.y = 0;
        transform.position += movementVector * sprint * movementSpeed * Time.deltaTime;
    }

    private void OnJump(InputValue input)
    {
        if (!grounded) return;

        characterRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnSprint(InputValue input)
    {
        sprint = 2;
    }

    private void OnSprintStop(InputValue input)
    {
        sprint = 1;
    }

    private void OnMovement(InputValue input)
    {
        movementInput = input.Get<Vector2>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }
}

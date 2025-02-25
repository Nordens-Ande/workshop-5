using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody characterRB;
    Vector3 movementInput;
    Vector3 movementVector;
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpForce;

    private float speedMultiplier = 1;
    private bool grounded = true;


    void Start()
    {
        characterRB = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        ApplyMovement();
    }


    //H�r apply-ar vi v�r movement med hj�lp utav den best�mda hastigheten, hastighetkonstanten (speedMultiplier, som best�ms av sprint och crouch) och r�relsevektorn
    private void ApplyMovement()
    {
        movementVector = transform.forward * movementInput.y + transform.right * movementInput.x;
        movementVector.y = 0;
        transform.position += movementVector * speedMultiplier * movementSpeed * Time.deltaTime;
    }


    //H�r genomf�r vi hoppet och kollar �ven ifall vi �r p� marken eller inte genom grounded
    private void OnJump(InputValue input)
    {
        if (!grounded) return;

        characterRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }


    //H�r �ndrar vi hastighet konstanten f�r 'sprint'. OBS nu �r det en �verdriven f�r�ndring f�r att det ska vara l�ttare att se/m�rka
    //Dessutom s� �ndrar vi objektets storlek f�r att visualisera att vi springer och f�r att det ser skitroligt ut
    private void OnSprint(InputValue input)
    {
        speedMultiplier = 3;
        transform.localScale = new Vector3(0.75f, 1, 1);
    }
    private void OnSprintStop(InputValue input)
    {
        speedMultiplier = 1;
        transform.localScale = new Vector3(1, 1, 1);
    }


    //H�r �ndrar vi hastighet konstanten f�r 'crouch'. OBS nu �r det en �verdriven f�r�ndring f�r att det ska vara l�ttare att se/m�rka
    //Dessutom s� �ndrar vi objektets storlek f�r att visualisera att vi crouch-ar
    private void OnCrouch(InputValue input)
    {
        speedMultiplier = 0.25f;
        transform.localScale = new Vector3(1, 0.5f, 1);
    }
    private void OnCrouchStop(InputValue input)
    {
        speedMultiplier = 1;
        transform.localScale = new Vector3(1, 1, 1);
    }


    private void OnMovement(InputValue input)
    {
        movementInput = input.Get<Vector2>();
    }


    //H�r �r v�ran rigidbody kollisioner som ser till ifall vi kan hoppa eller inte med hj�lp av grounded bool-en.
    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }
}

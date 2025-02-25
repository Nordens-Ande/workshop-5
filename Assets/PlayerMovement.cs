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


    //Här apply-ar vi vår movement med hjälp utav den bestämda hastigheten, hastighetkonstanten (speedMultiplier, som bestäms av sprint och crouch) och rörelsevektorn
    private void ApplyMovement()
    {
        movementVector = transform.forward * movementInput.y + transform.right * movementInput.x;
        movementVector.y = 0;
        transform.position += movementVector * speedMultiplier * movementSpeed * Time.deltaTime;
    }


    //Här genomför vi hoppet och kollar även ifall vi är på marken eller inte genom grounded
    private void OnJump(InputValue input)
    {
        if (!grounded) return;

        characterRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }


    //Här ändrar vi hastighet konstanten för 'sprint'. OBS nu är det en överdriven förändring för att det ska vara lättare att se/märka
    //Dessutom så ändrar vi objektets storlek för att visualisera att vi springer och för att det ser skitroligt ut
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


    //Här ändrar vi hastighet konstanten för 'crouch'. OBS nu är det en överdriven förändring för att det ska vara lättare att se/märka
    //Dessutom så ändrar vi objektets storlek för att visualisera att vi crouch-ar
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


    //Här är våran rigidbody kollisioner som ser till ifall vi kan hoppa eller inte med hjälp av grounded bool-en.
    private void OnCollisionEnter(Collision collision)
    {
        grounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }
}

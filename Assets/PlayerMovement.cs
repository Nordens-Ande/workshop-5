using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody characterRB;
    Transform characterTransform;
    Vector3 movementInput;
    Vector3 movementVector;
    [SerializeField] float movementSpeed;



    void Start()
    {
        characterRB = GetComponent<Rigidbody>();    
        characterTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        characterRB.position += movementVector * movementSpeed * Time.deltaTime;
    }

    private void OnMovement(InputValue input)
    {
        movementInput = input.Get<Vector2>();

        Debug.Log(characterTransform.rotation.y);
        movementVector.x = Mathf.Cos(characterTransform.rotation.y) * movementInput.x + Mathf.Sin(characterTransform.rotation.y) * movementInput.x;
        movementVector.z = Mathf.Cos(characterTransform.rotation.y) * movementInput.y + Mathf.Sin(characterTransform.rotation.y) * movementInput.y;
    }
}

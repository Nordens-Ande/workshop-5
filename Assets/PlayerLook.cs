using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] int mouseSensitivity;
    [SerializeField] GameObject camera;
    Vector2 rotation;
    Vector2 mouse;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        rotation.x -= mouse.y;
        rotation.y += mouse.x;

        Transform cameraTransform = GetComponent<Transform>();

        cameraTransform.rotation = Quaternion.Euler(rotation.x, rotation.y, 0);
    }

    private void OnLook(InputValue value)
    {
        mouse = value.Get<Vector2>() * mouseSensitivity * Time.deltaTime;


    }
}

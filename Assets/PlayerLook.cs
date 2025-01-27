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
        //Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnLook(InputValue value)
    {
        mouse = value.Get<Vector2>();
    }
}

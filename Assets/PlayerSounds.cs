using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSounds : MonoBehaviour
{
    
    private AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMovement(InputValue value)
    {
        audioSource.clip = SoundBank.Instance.stepSound;
        audioSource.loop = true;
        audioSource.Play();
    }

    private void OnMovementStop(InputValue value)
    {
        audioSource.loop = false;
        audioSource.clip = null;
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundBank : MonoBehaviour
{
    public static SoundBank Instance { get; private set; }

    [SerializeField] public AudioClip stepSound;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickMeUp : MonoBehaviour, IInteractable
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Interact()
    {
        Debug.Log("Picking me up sexy");
    }

    public void PickUp(Transform parentTransform)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        transform.parent = parentTransform;
        transform.position = parentTransform.position + parentTransform.right;
        transform.rotation = Quaternion.identity;
    }

    public void Drop()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;

        transform.SetParent(null);
    }
}

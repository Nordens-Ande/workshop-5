using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IInteractable
{
    void Interact();
    void PickUp(Transform parentTransform);
    void Drop();
}


public class PlayerInteract : MonoBehaviour
{

    [SerializeField] Camera camera;
    [SerializeField] float reach;

    Transform cameraTransform;
    
    void Start()
    {
        cameraTransform = camera.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(cameraTransform.position, cameraTransform.forward * reach, Color.red);
    }

    private void OnInteract(InputValue value)
    {

        RaycastHit hit;
        GameObject hitObject;
        IInteractable interactObject = null;

        Debug.DrawRay(cameraTransform.position, cameraTransform.forward * reach, Color.red);

        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, reach))
        {
            hitObject = hit.collider.gameObject;
            interactObject = hitObject.GetComponent<IInteractable>();
        }
        if (interactObject != null)
        {
            interactObject.Interact();
            interactObject.PickUp(transform);
        }
        else if (transform.childCount > 1)
        {
            foreach (Transform child in transform)
            {
                IInteractable interactableChild = child.gameObject.GetComponent<IInteractable>();
                if (interactableChild != null)
                    interactableChild.Drop();
            }
        }



        //else
        //{
        //    interactObject.Interact();
        //    interactObject.PickUp(transform);
        //}
    }
}

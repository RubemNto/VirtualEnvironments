using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : MonoBehaviour
{
    [SerializeField]
    private bool canInteract = false;
    [SerializeField]
    private GameObject interactableObject = null;
    public KeyCode interactKey = KeyCode.F;

    // Start is called before the first frame update
    void Start()
    {
        interactableObject = null;
        canInteract = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract == true && Input.GetKeyDown(interactKey))
        {
            //interact
            interactableObject.transform.GetChild(0).gameObject.SetActive(!interactableObject.transform.GetChild(0).gameObject.activeSelf);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("interactable"))
        {
            interactableObject = other.gameObject;
            canInteract = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        interactableObject = null;
        canInteract = false;
    }
}

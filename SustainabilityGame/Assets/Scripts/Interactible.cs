using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactible : MonoBehaviour
{
    public UnityEvent onInteract;
    public GameObject icon;
    public GameObject cameraAncor;

    bool isPlayerInRange;
    public bool isInteractive = true;

    private void Start()
    {
        isPlayerInRange = false;
        if(!CompareTag("Interactable")) { Debug.LogWarning("Interactible " + name + " does not have Interactible tag. This might or might not break things."); }
        if(gameObject.layer != 3) { Debug.LogWarning("Interactible " + name + " does not have Interactible layer. This might or might not break things."); }
    }

    private void Update()
    {
        if(isPlayerInRange)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                onInteract.Invoke();
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && isInteractive)
        {
            isPlayerInRange = true;
            icon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            icon.SetActive(false);
        }
    }

    public void SetInteractible(bool _activated)
    {
        isInteractive = _activated;
        icon.SetActive(_activated && isPlayerInRange);
    }
}

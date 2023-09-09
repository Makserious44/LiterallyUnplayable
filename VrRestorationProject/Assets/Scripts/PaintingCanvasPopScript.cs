using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(ComplexThrowableCopy))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(ObjectReturn))]

public class PaintingCanvasPopScript : MonoBehaviour
{
    private Transform parentObject;
    public void canvasPop()
    {
        GetComponent<Interactable>().enabled = true;
    }

    private void Start()
    {
        parentObject = gameObject.transform.parent;
        GetComponent<Interactable>().enabled = false;
        GetComponent<ComplexThrowableCopy>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    private void Update()
    {
        if (GetComponent<ObjectReturn>().isHeld)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<ComplexThrowableCopy>().enabled = true;
            gameObject.transform.parent = null;
        }
    }
}

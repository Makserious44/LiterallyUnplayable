using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
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
        GetComponent<ObjectReturn>().enabled = true;
    }

    private void Start()
    {
        parentObject = gameObject.transform.parent;
        GetComponent<Interactable>().enabled = false;
        GetComponent<ObjectReturn>().enabled = false;
        GetComponent<ComplexThrowableCopy>().enabled = false;
    }

    private void Update()
    {
        if (GetComponent<ObjectReturn>().isHeld)
        {
            GetComponent<ComplexThrowableCopy>().enabled = true;
            gameObject.transform.parent = null;
        }
    }

    public void canvasReturn()
    {
        parentObject = gameObject.transform.parent;
        gameObject.transform.position = Vector3.zero;
        gameObject.transform.rotation = new Quaternion();
        GetComponent<ComplexThrowableCopy>().enabled = false;
    }

    public void canvasFix()
    {
        GetComponent<Interactable>().enabled = false;
        GetComponent<ObjectReturn>().enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(ComplexThrowableCopy))]
[RequireComponent(typeof(ObjectReturn))]
[RequireComponent(typeof(ToolActionToolScript))]
[RequireComponent(typeof(FixedJoint))]


public class PaintingCanvasPopScript : MonoBehaviour
{
    private Transform parentObject;

    private Interactable interactable;
    private ObjectReturn objectReturn;
    private FixedJoint fixedJoint;
    private ComplexThrowableCopy complexThrowableCopy;
    private ToolActionToolScript toolActionToolScript;

    public void canvasPop()
    {
        transform.parent = null;
        fixedJoint.connectedBody = null;
        fixedJoint.breakForce = 0f;

        interactable.enabled = true;
        objectReturn.enabled = true;

        complexThrowableCopy.enabled = true;
        toolActionToolScript.enabled = true;

        Debug.Log($"{gameObject.name} popped");
    }

    private void Start()
    {
        interactable = GetComponent<Interactable>();
        objectReturn = GetComponent<ObjectReturn>();
        fixedJoint = GetComponent<FixedJoint>();
        complexThrowableCopy = GetComponent<ComplexThrowableCopy>();
        toolActionToolScript = GetComponent<ToolActionToolScript>();

        parentObject = transform.parent;

        //interactable.enabled = false;
        objectReturn.enabled = false;
        toolActionToolScript.enabled = false;

        //complexThrowableCopy.enabled = false;
    }

    private void Update()
    {
        if (objectReturn.isHeld && transform.parent != null)
        {
            Debug.Log($"{gameObject.name} unfixed");
            complexThrowableCopy.enabled = true;
            transform.parent = null;
        }
    }

    public void canvasReturn()
    {
        transform.parent = parentObject;
        transform.position = Vector3.zero;
        transform.rotation = new Quaternion();

        fixedJoint.connectedBody = parentObject.GetComponent<Rigidbody>();
        complexThrowableCopy.enabled = false;
    }

    public void canvasFix()
    {
        if (transform.parent != null)
        {
            interactable.enabled = false;
            objectReturn.enabled = false;
            toolActionToolScript.enabled = false;
        }
        
    }
}

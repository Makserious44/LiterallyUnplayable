using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Valve.VR;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(ComplexThrowableCopy))]
[RequireComponent(typeof(ObjectReturn))]
[RequireComponent(typeof(ToolActionToolScript))]
[RequireComponent(typeof(FixedJoint))]


public class PaintingCanvasPopScript : MonoBehaviour
{
    public Transform parentObject;

    private Interactable interactable;
    private ObjectReturn objectReturn;
    private FixedJoint fixedJoint;
    private ComplexThrowableCopy complexThrowableCopy;
    private ToolActionToolScript toolActionToolScript;

    public void canvasPop()
    {
        transform.parent = null;

        fixedJoint.breakForce = 0f;

        objectReturn.enabled = true;
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

        //interactable.enabled = false;
        objectReturn.enabled = false;
        toolActionToolScript.enabled = false;

        //complexThrowableCopy.enabled = false;
    }

    private void Update()
    {
        /*if (objectReturn.isHeld && transform.parent != null)
        {
            Debug.Log($"{gameObject.name} unfixed");
            transform.parent = null;
        }*/
    }

    public void canvasReturn()
    {
        interactable.attachedToHand.DetachObject(this.gameObject, true);
        transform.SetParent(parentObject, true);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(-90, 0, 0);
        if (fixedJoint == null)
        {
            interactable.attachedToHand.DetachObject(this.gameObject, true);

            fixedJoint = gameObject.AddComponent<FixedJoint>();
            fixedJoint.connectedBody = parentObject.GetComponent<Rigidbody>();
        }
        Debug.Log("Canvs fixed");
    }

    public void canvasFix()
    {
        if (transform.parent != null)
        {
            objectReturn.enabled = false;
            toolActionToolScript.enabled = false;
        }
        
    }
}

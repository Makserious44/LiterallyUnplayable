using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using Valve.VR;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(ComplexThrowableCopy))]
[RequireComponent(typeof(ObjectReturn))]
[RequireComponent(typeof(ToolActionToolScript))]
[RequireComponent(typeof(FixedJoint))]

[Serializable]
public class onPopEvent : UnityEvent {}

[Serializable]
public class onFixEvent : UnityEvent { }


public class PaintingCanvasPopScript : MonoBehaviour
{
    public Transform parentObject;

    private Interactable interactable;
    private ObjectReturn objectReturn;
    private FixedJoint fixedJoint;
    private ComplexThrowableCopy complexThrowableCopy;
    private ToolActionToolScript toolActionToolScript;

    public onPopEvent onPopCall;
    public onFixEvent onFixCall;

    public void canvasPop()
    {
        transform.parent = null;

        fixedJoint.breakForce = 0f;

        objectReturn.enabled = true;
        toolActionToolScript.enabled = true;

        onPopCall.Invoke();

        Debug.Log($"{gameObject.name} popped");
    }

    private void Start()
    {
        interactable = GetComponent<Interactable>();
        objectReturn = GetComponent<ObjectReturn>();
        fixedJoint = GetComponent<FixedJoint>();
        if (fixedJoint == null)
        {
            fixedJoint = gameObject.AddComponent<FixedJoint>();
            fixedJoint.connectedBody = parentObject.GetComponent<Rigidbody>();
        }
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
        transform.SetParent(parentObject, true);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(-90, 0, 0);
        if (fixedJoint == null)
        {
            /*if (objectReturn.isHeld)
            {
                for (int i = 0; i < complexThrowableCopy.holdingHands.Count; i++)
                {
                    complexThrowableCopy.holdingHands[i].DetachObject(this.gameObject);
                }
            }*/
            fixedJoint = gameObject.AddComponent<FixedJoint>();
            fixedJoint.connectedBody = parentObject.GetComponent<Rigidbody>();
            //fixedJoint.breakForce = 10f;
        }

        onFixCall.Invoke();

        Debug.Log("Canvs fixed");
    }

    public void canvasFix()
    {
        if (transform.parent != null)
        {
            fixedJoint.breakForce = Mathf.Infinity;
            objectReturn.enabled = false;
            toolActionToolScript.enabled = false;
        }
        
    }
}

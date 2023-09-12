using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(ComplexThrowableCopy))]
[RequireComponent(typeof(ObjectReturn))]
[RequireComponent(typeof(ToolActionToolScript))]

public class PaintingCanvasPopScript : MonoBehaviour
{
    private Transform parentObject;
    public void canvasPop()
    {
        Debug.Log($"{gameObject.name} popped");
        GetComponent<Interactable>().enabled = true;
        GetComponent<ObjectReturn>().enabled = true;
        GetComponent<ToolActionToolScript>().enabled = true;
        gameObject.AddComponent<Rigidbody>();
    }

    private void Start()
    {
        parentObject = gameObject.transform.parent;
        GetComponent<Interactable>().enabled = false;
        GetComponent<ObjectReturn>().enabled = false;
        GetComponent<ComplexThrowableCopy>().enabled = false;
        GetComponent<ToolActionToolScript>().enabled = false;
    }

    private void Update()
    {
        if (GetComponent<ObjectReturn>().isHeld)
        {
            Debug.Log($"{gameObject.name} unfixed");
            GetComponent<ComplexThrowableCopy>().enabled = true;
            gameObject.transform.parent = null;
        }
    }

    public void canvasReturn()
    {
        Destroy(gameObject.GetComponent(typeof(Rigidbody)));
        gameObject.transform.parent = parentObject;
        gameObject.transform.position = Vector3.zero;
        gameObject.transform.rotation = new Quaternion();
        GetComponent<ComplexThrowableCopy>().enabled = false;
    }

    public void canvasFix()
    {
        GetComponent<Interactable>().enabled = false;
        GetComponent<ObjectReturn>().enabled = false;
        GetComponent<ToolActionToolScript>().enabled = false;
    }
}

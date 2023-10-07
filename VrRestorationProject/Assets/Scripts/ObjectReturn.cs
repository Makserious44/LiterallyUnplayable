using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(ComplexThrowableCopy))]

public class ObjectReturn : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;
    public bool isHeld;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = gameObject.transform.position;
        startRotation = gameObject.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        isHeld = GetComponent<ComplexThrowableCopy>().holdingHands.Count > 0;

        if (startPosition.y - gameObject.transform.position.y >= 0.5 && !isHeld)
        {
            gameObject.transform.position = startPosition;
            gameObject.transform.rotation = startRotation;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}

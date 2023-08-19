using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReturn : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = gameObject.transform.position;
        startRotation = gameObject.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (startPosition.y - gameObject.transform.position.y >= 0.5)
        {
            gameObject.transform.position = startPosition;
            gameObject.transform.rotation = startRotation;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}

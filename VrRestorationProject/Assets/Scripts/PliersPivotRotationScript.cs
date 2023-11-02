using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PliersPivotRotationScript : MonoBehaviour
{
    public GameObject rotationPivot;
    public GameObject leftHandle;
    public GameObject rightHandle;

    private bool isHolding = false;

    public void interaction()
    {
        if (!isHolding)
        {
            leftHandle.transform.RotateAround(rotationPivot.transform.position, Vector3.up, 20f);
            rightHandle.transform.RotateAround(rotationPivot.transform.position, Vector3.up, -20f);
        }
        else
        {

        }
    }
}

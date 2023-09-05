using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class leafHolderCall : UnityEvent {}

public class LeafHolderScript : MonoBehaviour
{
    public leafHolderCall callObject;
    public int requiresCallsToActivate;
    public bool isActive;

    private int callsCount = 0;

    // Start is called before the first frame update

    public void activationGate()
    {
        callsCount++;

        if (callsCount == requiresCallsToActivate)
        {
            isActive = true;
        }
    }

    public void Interaction()
    {
        isActive = false;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class callObjectsActivate : UnityEvent {}

[Serializable]
public class callObjectsDectivate : UnityEvent { }

[Serializable]
public class callObjectInteract : UnityEvent { }

public class ToolActionObjectScript : MonoBehaviour
{
    public callObjectsActivate callObject;
    public callObjectsDectivate decallObject;
    public callObjectInteract interactionObject;

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

    public void deactivationGate()
    {
        callsCount--;

        if (callsCount != requiresCallsToActivate)
        {
            isActive = false;
        }
    }

    public void Interaction()
    {
        interactionObject.Invoke();
        isActive = false;
    }
}

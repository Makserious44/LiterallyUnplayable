using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class callObjectInteract : UnityEvent { }

[Serializable]
public class callObjectDeactivateEvent : UnityEvent { }

public class ToolActionObjectScript : MonoBehaviour
{
    public callObjectInteract interactionObject;
    public callObjectDeactivateEvent deactivationEvent;

    public int requiresCallsToActivate;
    public bool isActive;
    public bool interactOnActivation = false;

    private int callsCount = 0;

    // Start is called before the first frame update

    public void activationGate()
    {
        callsCount++;

        if (callsCount == requiresCallsToActivate)
        {
            isActive = true;
            if (interactOnActivation)
            {
                Interaction();
            }
        }
    }

    public void deactivationGate()
    {
        callsCount--;

        if (callsCount != requiresCallsToActivate)
        {
            isActive = false;
            deactivationEvent.Invoke();
        }
    }

    public void Interaction()
    {
        Debug.Log($"{gameObject.name} activated");
        interactionObject.Invoke();
        isActive = false;
    }
}

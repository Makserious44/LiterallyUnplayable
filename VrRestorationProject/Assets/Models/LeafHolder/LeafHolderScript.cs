using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class leafHolderCall : UnityEvent {}

[Serializable]
public class leafHolderDecall : UnityEvent { }

public class LeafHolderScript : MonoBehaviour
{
    public leafHolderCall callObject;
    public leafHolderDecall decallObject;
    public int requiresCallsToActivate;
    public bool isActive;
    private bool isActivated = false;

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
        if (!isActivated)
        {
            gameObject.GetComponent<Transform>().Rotate(-90, 0, 0);
            callObject.Invoke();
            isActivated = true;
        }
        else
        {
            gameObject.GetComponent<Transform>().Rotate(90, 0, 0);
            decallObject.Invoke();
            isActivated = false;
        }
    }
}

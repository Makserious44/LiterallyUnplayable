using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ToolActionToolScript : MonoBehaviour
{
    [TagField]
    [SerializeField] public string tagToInteract;

    public ToolActionHandScript RightHand;
    public ToolActionHandScript LeftHand;
    private int holdingHandsCount;

    private void InteractAction(Collider TriggerObject)
    {
        Destroy(TriggerObject.gameObject);
    }

    private void UpdateHand(ToolActionHandScript Hand, Collider TriggerObject)
    {
        if (Hand.isGrabbing && Hand.isInteracting)
        {
            InteractAction(TriggerObject);
        }
    }

    private void Update()
    {
        holdingHandsCount = GetComponent<ComplexThrowableCopy>().holdingHands.Count;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == tagToInteract && holdingHandsCount > 0)
        {
            UpdateHand(RightHand, other);
            UpdateHand(LeftHand, other);
        }
    }
}

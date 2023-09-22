using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;
using Valve.VR.InteractionSystem;

[Serializable]
public class toolInteractionEvent : UnityEvent { }

public class ToolActionToolScript : MonoBehaviour
{
    [TagField]
    [SerializeField] public string tagToInteract;

    public Material activeMaterial;
    public Material inactiveMaterial;

    public toolInteractionEvent toolEvent;
    public ToolActionHandScript RightHand;
    public ToolActionHandScript LeftHand;

    private int holdingHandsCount;
    private Animator animator;

    private void stopAnim()
    {
        animator.SetBool("isInAction", false);
    }

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void InteractAction(Collider TriggerObject)
    {
        if (animator != null)
        {
            animator.SetBool("isInAction", true);
            Invoke("stopAnim", 2);
        }
        if (toolEvent != null)
        {
            toolEvent.Invoke();
        }
        //animator.Play("BrushAction");
        //Destroy(TriggerObject.gameObject, 2);
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

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == tagToInteract && holdingHandsCount > 0 && other.gameObject.GetComponent<ToolActionObjectScript>().isActive)
        {
            GetComponent<MeshRenderer>().material = activeMaterial;
            UpdateHand(RightHand, other);
            UpdateHand(LeftHand, other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        GetComponent<MeshRenderer>().material = inactiveMaterial;
    }
}

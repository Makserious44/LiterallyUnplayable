using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
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

    public static Material activeMaterial;
    public static Material inactiveMaterial;
    public bool toggleTriggerDebug;

    public toolInteractionEvent onToolInteractionEvent;
    public ToolActionHandScript RightHand;
    public ToolActionHandScript LeftHand;

    private int holdingHandsCount;
    private Animator animator;

    private void stopAnim()
    {
        animator.SetBool("isInAction", false);
    }

    void Start()
    {
        if (RightHand ==  null)
            RightHand = GameObject.FindWithTag("RightHand").GetComponent<ToolActionHandScript>();
        if (LeftHand == null)
            LeftHand = GameObject.FindWithTag("LeftHand").GetComponent<ToolActionHandScript>();

        animator = GetComponentInChildren<Animator>();
        activeMaterial = Resources.Load<Material>("DebugActive");
        inactiveMaterial = Resources.Load<Material>("DebugInactive");
    }

    private void InteractAction(Collider TriggerObject)
    {
        TriggerObject.gameObject.GetComponent<ToolActionObjectScript>().Interaction();
        if (animator != null)
        {
            animator.SetBool("isInAction", true);
            Invoke("stopAnim", 2);
        }

        if (onToolInteractionEvent != null)
            onToolInteractionEvent.Invoke();
        //animator.Play("ToolAction");
        //Destroy(TriggerObject.gameObject, 2);
    }

    private void UpdateHand(ToolActionHandScript Hand, Collider TriggerObject)
    {
        if (Hand.isGrabbing && Hand.isInteracting)
            InteractAction(TriggerObject);
    }

    private void Update()
    {
        holdingHandsCount = GetComponent<ComplexThrowableCopy>().holdingHands.Count;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Object Tag: {other.tag}\nObject Action Script: {other.GetComponent<ToolActionObjectScript>()}\nHolding Hands: {holdingHandsCount}");
        if (other.tag == tagToInteract && holdingHandsCount > 0 && other.gameObject.GetComponent<ToolActionObjectScript>().isActive && toggleTriggerDebug)
        {
            if (TryGetComponent<MeshRenderer>(out MeshRenderer meshRenderer))
                meshRenderer.material = activeMaterial;
            else
                GetComponentInChildren<MeshRenderer>().material = activeMaterial;
        }            
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == tagToInteract && holdingHandsCount > 0 && other.gameObject.GetComponent<ToolActionObjectScript>().isActive)
        {
            UpdateHand(RightHand, other);
            UpdateHand(LeftHand, other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (toggleTriggerDebug)
        {
            if (TryGetComponent<MeshRenderer>(out MeshRenderer meshRenderer))
                meshRenderer.material = inactiveMaterial;
            else
                GetComponentInChildren<MeshRenderer>().material = inactiveMaterial;

        }
    }
}

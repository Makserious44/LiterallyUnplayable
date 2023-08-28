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
    private Animator animator;

    /*private void stopAnim()
    {
        animator.
    }*/

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void InteractAction(Collider TriggerObject)
    {
        animator.Play("BrushActionAnim");
        Destroy(TriggerObject.gameObject, 2);
        //Invoke("stopAnim", 2);
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
        if (other.tag == tagToInteract && holdingHandsCount > 0)
        {
            UpdateHand(RightHand, other);
            UpdateHand(LeftHand, other);
        }
    }
}

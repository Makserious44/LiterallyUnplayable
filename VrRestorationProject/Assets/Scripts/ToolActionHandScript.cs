using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Valve.VR;

public class ToolActionHandScript : MonoBehaviour
{
    [TagField]
    [SerializeField] public string tagToInteract;

    public bool isGrabbing;
    public bool isInteracting;
    public SteamVR_Input_Sources Hand;
    public SteamVR_Action_Boolean HandGripButton;
    public SteamVR_Action_Boolean HandInteractButton;

    private void Update()
    {
        if (HandGripButton.GetState(Hand))
        {
            isGrabbing = true;
        }
        else
        {
            isGrabbing = false;
        }

        if (HandInteractButton.GetState(Hand))
        {
            isInteracting = true;
        }
        else
        {
            isInteracting = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == tagToInteract)
        {
            if (HandInteractButton.GetStateDown(Hand))
            {
                other.gameObject.GetComponent<LeafHolderScript>().Interaction();
            }
        }
    }
}

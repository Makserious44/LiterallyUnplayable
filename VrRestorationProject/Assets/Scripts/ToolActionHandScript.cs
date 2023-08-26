using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ToolActionHandScript : MonoBehaviour
{
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
}

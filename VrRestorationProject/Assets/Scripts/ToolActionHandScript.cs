using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ToolActionHandScript : MonoBehaviour
{
    public SteamVR_Action_Boolean handGrab;
    public SteamVR_Action_Boolean toolInteract;
    public SteamVR_Input_Sources hand;
    private GameObject tool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (handGrab.GetStateDown(hand))
        {
            tool = gameObject.
        }
    }
}

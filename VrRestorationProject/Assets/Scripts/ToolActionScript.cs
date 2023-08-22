using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using Cinemachine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ToolActionScript : MonoBehaviour
{
    [TagField]
    [SerializeField] private string tagToInteractWith;
    public SteamVR_Action_Boolean actionButton;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagToInteractWith) && actionButton.GetStateDown())
        {

        }
    }
}

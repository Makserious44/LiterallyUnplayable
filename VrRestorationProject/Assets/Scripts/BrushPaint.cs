using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.Newtonsoft.Json.Bson;

public class BrushPaint : MonoBehaviour
{
    Material defaultMaterial;
    private void Start()
    {
        defaultMaterial = GetComponentInChildren<MeshRenderer>().material;
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BrushPaint")
        {
            GetComponentInChildren<ChangeMaterialScript>().Change();
            GetComponent<ToolActionToolScript>().tagToInteract = "InteractsWithOiledBrush";
        }
        else if (other.tag == "Water")
        {
            GetComponentInChildren<MeshRenderer>().material = defaultMaterial;
            GetComponent<ToolActionToolScript>().tagToInteract = "InteractsWithBrush";
        }
    }
}

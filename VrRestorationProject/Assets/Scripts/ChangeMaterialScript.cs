using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialScript : MonoBehaviour
{
    public Material material;
    // Start is called before the first frame update
    public void Change()
    {
        gameObject.GetComponent<MeshRenderer>().material = material;
    }
}

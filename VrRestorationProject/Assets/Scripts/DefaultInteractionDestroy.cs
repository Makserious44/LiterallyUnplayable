using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultInteractionDestroy : MonoBehaviour
{
    public void destroySelf()
    {
        Destroy(gameObject);
    }
}

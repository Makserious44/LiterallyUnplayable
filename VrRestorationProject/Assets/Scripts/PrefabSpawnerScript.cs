using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PrefabSpawnerScript : MonoBehaviour
{
    public GameObject prefab;
    private GameObject objectSpawned;
    public void spawnPrefab()
    {
        if (objectSpawned != null)
        {
            Destroy(objectSpawned);
        }
        Vector3 spawmPosition = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
        objectSpawned = Instantiate(prefab, spawmPosition, Quaternion.identity);
    }
}

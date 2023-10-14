using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PrefabSpawnerScript : MonoBehaviour
{
    public GameObject prefab;
    public GameObject spawnPlatform;

    private GameObject objectSpawned;
    public void spawnPrefab()
    {
        if (objectSpawned != null)
        {
            Destroy(objectSpawned);
        }
        Vector3 spawmPosition = new Vector3(spawnPlatform.transform.position.x, spawnPlatform.transform.position.y + 0.1f, spawnPlatform.transform.position.z);
        objectSpawned = Instantiate(prefab, spawmPosition, Quaternion.identity);
    }
}

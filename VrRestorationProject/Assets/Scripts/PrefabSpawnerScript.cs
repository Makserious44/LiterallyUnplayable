using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PrefabSpawnerScript : MonoBehaviour
{
    public GameObject prefab;
    public GameObject spawnPlatform;

    private GameObject objectArtSpawned;
    private GameObject objectToolSpawned;
    private GameObject objectMiscSpawned;

    public void spawnPrefab()
    {
        Vector3 spawnPosition = new Vector3(spawnPlatform.transform.position.x, spawnPlatform.transform.position.y + 0.1f, spawnPlatform.transform.position.z);
        switch (prefab.tag)
        {
            case "Art":
                if (objectArtSpawned != null) Destroy(objectArtSpawned);
                objectArtSpawned = Instantiate(prefab, spawnPosition, Quaternion.identity);
                break;
            case "Tool":
                if (objectToolSpawned != null) Destroy(objectToolSpawned);
                objectToolSpawned = Instantiate(prefab, spawnPosition, Quaternion.identity);
                break;
            default:
                if (objectMiscSpawned) Destroy(objectMiscSpawned);
                objectMiscSpawned = Instantiate(prefab, spawnPosition, Quaternion.identity);
                break;
        }
    }
}

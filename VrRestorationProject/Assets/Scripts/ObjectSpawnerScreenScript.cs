using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(PrefabSpawnerScript))]

public class ObjectSpawnerScreenScript : MonoBehaviour
{
    public List<GameObject> spawnObjects;
    public GameObject screenText;

    private PrefabSpawnerScript prefabSpawnerScript;
    private GameObject prefabToSpawn;
    private TextMeshPro textMesh;

    private int listIter = 0;
    private int listSize;

    void Start()
    {
        listSize = spawnObjects.Count;

        prefabSpawnerScript = GetComponent<PrefabSpawnerScript>();
        textMesh = screenText.GetComponent<TextMeshPro>();

        prefabToSpawn = spawnObjects[0];
        prefabSpawnerScript.prefab = spawnObjects[0];
    }

    private void Update()
    {
        textMesh.text = $"Selected object:\n{prefabToSpawn.name}";
    }

    public void prefabsIterIncr()
    {
        if (listIter + 1 > listSize)
        {
            listIter = 0;
        }
        else
        {
            listIter++;
        }

        prefabToSpawn = spawnObjects[listIter];
        prefabSpawnerScript.prefab = prefabToSpawn;
    }

    public void prefabsIterDecr()
    {
        if (listIter - 1 < 0)
        {
            listIter = listSize;
        }
        else
        {
            listIter--;
        }

        prefabToSpawn = spawnObjects[listIter];
        prefabSpawnerScript.prefab = prefabToSpawn;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileSpawner : MonoBehaviour
{
    public GameObject pileObject;

    private Vector3 spawnPosition;
    // Start is called before the first frame update

    private void Start()
    {
        spawnPosition = transform.position;
        spawnPosition.y += 1f;
    }
    public void spawnObject()
    {
        Instantiate(pileObject, spawnPosition, Quaternion.identity);
    }
}

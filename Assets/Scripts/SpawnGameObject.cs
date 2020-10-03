using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGameObject : MonoBehaviour
{
    public GameObject spawnObject;
    public Transform parent  = null;
    public Vector3 position;
    public bool useTransformPosition = true;

    public void SpawnObject() {
        if(parent == null)
            Instantiate(spawnObject, useTransformPosition? transform.position : position, Quaternion.identity);
        else
            Instantiate(spawnObject, parent);
    }
}

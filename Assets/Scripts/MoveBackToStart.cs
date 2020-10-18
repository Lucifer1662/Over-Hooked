using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackToStart : MonoBehaviour
{
    private Vector3 position;
    private Quaternion rotation;
    private void Start()
    {
        position = transform.position;
        rotation = transform.rotation;
        
    }
    public void MoveBack() {
        transform.position = position;
        transform.rotation = rotation;
    }
}

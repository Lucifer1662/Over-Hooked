﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveMidAir : MonoBehaviour {
    public float strength = 0.01f;
    Vector3 deltaPos;
    Rigidbody rb;

    void Start () {
        rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit)){
            deltaPos = hit.point - transform.position;
        }
        deltaPos.y = 0;
        deltaPos.x = Mathf.Clamp(deltaPos.x, -6, 4);
        deltaPos.z = Mathf.Clamp(deltaPos.z, -6, 4);
        // Debug.Log(deltaPos);
        rb.AddForce(deltaPos * strength);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterEvent : MonoBehaviour
{
    public int mask;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10) {
            Destroy(gameObject);
        }

    }
}

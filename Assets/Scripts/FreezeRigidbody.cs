﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeRigidbody : MonoBehaviour
{

    public void freezeRigidbody() {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
    }
}

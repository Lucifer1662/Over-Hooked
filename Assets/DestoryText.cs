using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryText : MonoBehaviour
{
    public float destoryTime = 6f;
    void Start()
    {
       Destroy(gameObject, destoryTime);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FocusController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            Debug.Log("Lost Focus");
            EventSystem.current.SetSelectedGameObject(gameObject);
        }
    }
}

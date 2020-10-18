using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class BelowYEvent : UnityEvent {}
public class BelowY : MonoBehaviour
{
    [SerializeField]
    public BelowYEvent belowYEvent;

    public float y;
    bool called = false;
    public bool repeat = false;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= y && !called)
        {
            belowYEvent.Invoke();
            if(!repeat)
                called = true;
        }
    }
}

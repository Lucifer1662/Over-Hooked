using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class NextEvent : UnityEvent { }
public class TuroialNext : MonoBehaviour
{
    [SerializeField]
    public NextEvent next;
    public Tutorial tutorial;
    public void Next() {
        if (enabled && gameObject.activeSelf)
        {
            next.Invoke();
            tutorial.Next();
        }
    }
}

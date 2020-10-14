using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnStartEvent : UnityEvent { }
public class OnStart : MonoBehaviour
{
    [SerializeField]
    public OnStartEvent onStart;
    // Start is called before the first frame update
    void Start()
    {
        onStart.Invoke();
    }

}

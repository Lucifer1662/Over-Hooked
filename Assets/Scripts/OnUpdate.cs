using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnUpdateEvent : UnityEvent { }
public class OnUpdate : MonoBehaviour
{
    [SerializeField]
    public OnUpdateEvent onUpdate;
    // Start is called before the first frame update
    void Update()
    {
        onUpdate.Invoke();
    }

}

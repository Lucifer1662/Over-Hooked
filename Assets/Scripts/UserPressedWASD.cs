using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UserPressedWASDEvent : UnityEvent { }
public class UserPressedWASD : MonoBehaviour
{
    [SerializeField]
    public UserPressedWASDEvent userPressedWASDEvent;


    // Update is called once per frame
    void FixedUpdate()
    {
        var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Mathf.Abs(input.x) > 0.1 || Mathf.Abs(input.y) > 0.1) {
            userPressedWASDEvent.Invoke();
        }
    }
}

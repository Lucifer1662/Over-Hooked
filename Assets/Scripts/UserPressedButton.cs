﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UserPressedButtonEvent : UnityEvent { }
public class UserPressedButton : MonoBehaviour
{
    [SerializeField]
    public UserPressedButtonEvent userPressedButton;
    [SerializeField]
    public List<string> buttons;

    // Update is called once per frame
    public void FixedUpdate()
    {
        foreach (string button in buttons)
        {
            var input = Input.GetButtonUp(button);
            if (input)
            {
                Debug.Log("Presed");
                userPressedButton.Invoke();
            }
        }
    }
}

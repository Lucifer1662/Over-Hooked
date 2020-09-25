using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleEnable : MonoBehaviour
{
    public List<GameObject> targets;
    public void toggleEnable()
    {
        targets.ForEach((target)=> { target.SetActive(!target.activeSelf); });
    }
}

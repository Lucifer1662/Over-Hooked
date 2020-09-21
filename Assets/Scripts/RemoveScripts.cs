using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveScripts : MonoBehaviour
{
    public List<string> components;
    public void removeScripts() {
        foreach (var compName in components)
        {
            Destroy(GetComponent(compName));
        }
    }
}

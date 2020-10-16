using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchFishNext : MonoBehaviour
{

    public Tutorial tutorial;
    // Start is called before the first frame update
    public void Next() {
        Debug.Log(enabled);
        Debug.Log(gameObject.activeSelf);
        if (enabled && gameObject.activeSelf)
            if (tutorial)
                tutorial.Next();
    }
}

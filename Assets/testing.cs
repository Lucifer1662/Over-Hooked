using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour
{
    private GameObject hook;
    private Vector3 lasthook;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(PlayerRodControl.hookInstance != null){
            hook = PlayerRodControl.hookInstance;
            
            print(hook.transform.position);

            Debug.Log(lasthook);
        
            
            lasthook = hook.transform.position;
        }
        

    }
}

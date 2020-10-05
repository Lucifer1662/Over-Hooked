using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishComeToBait : MonoBehaviour
{
    private float distance;
    public float speed = 5;
    public float effectiveRange = 10;
    private GameObject curHook;
    private Vector3 lastHook;
    private RaycastHit hit;



    // Update is called once per frame
    void FixedUpdate()
    {
        
        curHook = PlayerRodControl.hookInstance;
        
        if(curHook != null && lastHook != null){
            // print(curHook);
            // Debug.Log(lastHook);

            if(Vector3.Distance(curHook.transform.position, lastHook) < .001f) {
                 
                distance = Vector3.Distance(curHook.transform.position, transform.position);
                // if (!outsideTerrain(lastHook)){
                //     print("!!!!!!!");
                // }
                if(closeEnough(distance)){
                    transform.LookAt(curHook.transform);
                    GetComponent<FishMovement>().enabled = false;
                    transform.position = Vector3.MoveTowards(transform.position, curHook.transform.position, speed * Time.deltaTime);
                }
            }else{
                lastHook = curHook.transform.position;
            }
        
        }else{
            if (curHook != null){
                lastHook = curHook.transform.position; 
            }
            
            GetComponent<FishMovement>().enabled = true;
        }

    }

    bool closeEnough(float distance){
        if (distance <= effectiveRange){
            return true;
        }
        return false;
    }

}

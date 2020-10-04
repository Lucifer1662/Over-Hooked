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
                    move(speed);
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

    void move(float speed){
        Vector3 newPosition = this.transform.position + this.transform.forward * 5;
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // private bool outsideTerrain(Vector3 newLocation)
    // {
    //     bool terrain = true;
    //     Vector3 castLocation = new Vector3(newLocation.x, newLocation.y + 100, newLocation.z);

    //     Physics.Raycast(castLocation, newLocation - castLocation, out hit, 1000);
        
    //     // If distance is <100 then position is "inside" terrain
    //     if(hit.distance < 100){
    //         terrain = false;
    //     }

    //     return terrain;
    // }
}

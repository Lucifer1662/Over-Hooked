using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishComeToBait : MonoBehaviour
{
    private float distance;
    public float speed = 5;
    public float effectiveRange = 20;
    private GameObject curHook;
    private Vector3 lastHook;



    // Update is called once per frame
    void FixedUpdate()
    {
        
        curHook = PlayerRodControl.hookInstance;
        
        if(curHook != null && lastHook != null){
            print(curHook);
            Debug.Log(lastHook);

            if(Vector3.Distance(curHook.transform.position, lastHook) < .001f) {
                 
                distance = Vector3.Distance(curHook.transform.position, transform.position);
                if (closeEnough(distance)){
                    GetComponent<FishMovement>().enabled = false;
                    transform.LookAt(curHook.transform);
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
}

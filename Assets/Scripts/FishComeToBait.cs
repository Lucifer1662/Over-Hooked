using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishComeToBait : MonoBehaviour
{
    private float distance;
    public float speed = 3;
    public float effectiveRange = 10;
    private GameObject curHook;
    private Vector3 lastHook;
    private RaycastHit hit;
    private Rigidbody rb;

    private float backwardSpeed = 5;



    // Update is called once per frame
    void FixedUpdate()
    {

        curHook = GameObject.FindGameObjectWithTag("Hook");
        
        if(curHook != null && lastHook != null){
            // print(curHook);
            // Debug.Log(lastHook);

            if(Vector3.Distance(curHook.transform.position, lastHook) < .001f) {
                 
                distance = Vector3.Distance(curHook.transform.position, transform.position);

                if(closeEnough(distance)){
                    transform.LookAt(curHook.transform);
                    
                    GetComponent<moveTowards>().enabled = true;

                    if (Vector3.Distance(curHook.transform.position, transform.position) <= 5){
                        int attemptTimes = Random.Range(0, 3); // random select times to attempt to bite
                        attemptToBite(attemptTimes, curHook.transform.position - transform.position);
                    }
                    
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

    void attemptToBite(int times, Vector3 direction){
        if (times == 0){
            return;
        }
        GetComponent<moveTowards>().enabled = false;
        direction = -direction;
        rb = GetComponent<Rigidbody>();
        direction.y = 0;
        rb.AddForce(direction * 0.1f, ForceMode.Impulse);
        // GetComponent<moveTowards>().enabled = true;

    }



}

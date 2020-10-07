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
    private float time = 0.0f;
    public float interpolationPeriod = 3f;
    private int attemptTimes = 1;


    // Update is called once per frame
    void FixedUpdate()
    {

        curHook = GameObject.FindGameObjectWithTag("Hook");
        Vector3 waterlevelHookPos;
        
        if(curHook != null && lastHook != null){
            waterlevelHookPos = curHook.transform.position;
            waterlevelHookPos.y = 0;
            // print(curHook);
            // Debug.Log(lastHook);

            if(Vector3.Distance(waterlevelHookPos, lastHook) < .001f) {
                 
                distance = Vector3.Distance(waterlevelHookPos, transform.position);

                if(closeEnough(distance)){
                    transform.LookAt(curHook.transform);
                    
                    GetComponent<moveTowards>().enabled = true;
                    rb = GetComponent<Rigidbody>();
                    if (Vector3.Distance(waterlevelHookPos, transform.position) <= 5){
                        time += Time.deltaTime;
 
                        if (time >= interpolationPeriod) {
                            time = time - interpolationPeriod;
                            attemptTimes = Random.Range(0, 2);
                        }
                        attemptToBite(attemptTimes, waterlevelHookPos - transform.position);
                     


                        
                        // Debug.Log(attemptTimes); // random select times to attempt to bite

                    }
                    
                }
            }else{
                lastHook = waterlevelHookPos;
            }
        
        }else{
            if (curHook != null){
                waterlevelHookPos = curHook.transform.position;
                waterlevelHookPos.y = 0;
                lastHook = waterlevelHookPos;
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
            GetComponent<moveTowards>().enabled = true;
            return;
        }
        
        direction = -direction;
        rb = GetComponent<Rigidbody>();
        direction.y = 0;
        rb.AddForce(direction * 0.1f, ForceMode.Impulse);
        // GetComponent<moveTowards>().enabled = true;

    }

    IEnumerator waitfor(Vector3 direction){
        yield return new WaitForSeconds(1);
        rb.AddForce(direction * 0.03f, ForceMode.Impulse);
        yield return new WaitForSeconds(3);
        GetComponent<moveTowards>().enabled = true;

    }

}

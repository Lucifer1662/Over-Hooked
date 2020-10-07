using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTowards : MonoBehaviour

{
    public float speed = 3;
    private GameObject curHook;
    // Start is called before the first frame update


    // Update is called once per frame
    void FixedUpdate()
    {
        curHook = GameObject.FindGameObjectWithTag("Hook");
        if (curHook != null){
            GetComponent<FishMovement>().enabled = false;

            Vector3 waterlevelHookPos = curHook.transform.position;
            waterlevelHookPos.y = 0;
            
            //Debug.Log("Hook position is " + waterlevelHookPos);
            //Debug.Log("Fish position is " + transform.position);
            transform.position = Vector3.MoveTowards(transform.position, waterlevelHookPos, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }else{
            GetComponent<FishMovement>().enabled = true;
        }
        
    }
}

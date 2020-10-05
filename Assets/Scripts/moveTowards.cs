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
            transform.position = Vector3.MoveTowards(transform.position, curHook.transform.position, speed * Time.deltaTime);
        }else{
            GetComponent<FishMovement>().enabled = true;
        }
        
    }
}

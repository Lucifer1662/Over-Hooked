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
            var target = curHook.transform.position;
            target.y = transform.position.y;
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            transform.LookAt(target);
        }else{
            GetComponent<FishMovement>().enabled = true;
        }
        
    }
}

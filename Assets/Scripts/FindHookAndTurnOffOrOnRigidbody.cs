using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindHookAndTurnOffOrOnRigidbody : MonoBehaviour
{
    public Vector3 velocity;

    public void ToggleHookRigidBody() {
        var hook = GameObject.FindGameObjectWithTag("Hook");
        if (hook) {
            var rigid = hook.GetComponent<Rigidbody>();
            if (rigid) {
                
                if (rigid.constraints == RigidbodyConstraints.FreezeAll)
                {
                    rigid.constraints = RigidbodyConstraints.None;
                    rigid.velocity = velocity;
                   
                }
                else {
                    velocity = rigid.velocity;
                    rigid.constraints = RigidbodyConstraints.FreezeAll;
                }
            }
            
        }
    }
}

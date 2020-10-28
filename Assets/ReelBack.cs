using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelBack : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.position.y >= 0.3f){
            rb.constraints = RigidbodyConstraints.None;
        }else{
            var d = Input.GetAxis("Mouse ScrollWheel");

            //scroll down
            if (d < 0f){
                GameObject player = GameObject.FindWithTag("Player");
                var movingDirection = player.transform.position;
                movingDirection.y = -0.2f;
                rb.constraints = RigidbodyConstraints.None;
                rb.constraints = RigidbodyConstraints.FreezeRotation;
                Mathf.Clamp(transform.position.y, 0.2f, 10f);
                rb.AddForce((player.transform.position - transform.position)*0.05f);
            }else{
                rb.constraints = RigidbodyConstraints.FreezeAll;
            }
            if (GetComponent<CatchFish>().stopMoving) {
				rb.constraints = RigidbodyConstraints.FreezeAll;
			}
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTowards : MonoBehaviour

{
    public float speed = 3;
    private GameObject curHook;
	public float distanceOfEffect = 2;


    // Update is called once per frame
    void FixedUpdate()
    {
        curHook = GameObject.FindGameObjectWithTag("Hook");
        if (curHook != null){
			if (closeEnough() && curHook.transform.position.y <= 0.7) {
				GetComponent<FishMovement> ().enabled = false;
				var target = curHook.transform.position;
				target.y = transform.position.y;
				transform.position = Vector3.MoveTowards (transform.position, target, speed * Time.deltaTime);
				transform.LookAt (target);
			}
			return;
        }

        GetComponent<FishMovement>().enabled = true;
    }

	bool closeEnough()
	{
		return Vector2.Distance (new Vector2 (curHook.transform.position.x, curHook.transform.position.y),
								new Vector2 (transform.position.x, transform.position.y)) < distanceOfEffect;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTowards : MonoBehaviour

{
    public float speed = 3;
    private GameObject curHook;
	public float distanceOfEffect = 6;


    // Update is called once per frame
    void FixedUpdate()
    {
        curHook = GameObject.FindGameObjectWithTag("Hook");
        if (curHook != null){
			if (closeEnough() && curHook.transform.position.y <= 0.7) {
                Debug.Log("Go Towards");
				GetComponent<FishMovement> ().enabled = false;
				var target = curHook.transform.position;
				target.y = transform.position.y;
                if(notTooClose()){
                    transform.position += transform.forward * speed * Time.deltaTime;
				    changeDirection(target);
                }else {
                    Debug.Log("Too close, stop moving");
                }
				
			}
			return;
        }

        GetComponent<FishMovement>().enabled = true;
    }

	bool closeEnough()
	{
		return Vector2.Distance (new Vector2 (curHook.transform.position.x, curHook.transform.position.z),
								new Vector2 (transform.position.x, transform.position.z)) < distanceOfEffect;
	}

    bool notTooClose() {
        return Vector2.Distance(new Vector2(curHook.transform.position.x, curHook.transform.position.z),
                                    new Vector2(transform.position.x, transform.position.z)) >= 0.4f;
    }

	// Gradually rotate
    void changeDirection(Vector3 newPosition){
        Vector3 newRotation = Vector3.RotateTowards(transform.forward, newPosition, Time.deltaTime, 0.0f);
        
        // Set rotation speed according to fish type
        float rotationFactor;
        if (this.name == "FishSmall(Clone)"){
            rotationFactor = 5f;
        }
        else if (this.name == "FishMedium(Clone)"){
            rotationFactor = 4f;
        }else {
            rotationFactor = 3f;
        }
        
        if ((newPosition - transform.position) != Vector3.zero){
            Quaternion rotation = Quaternion.LookRotation(newPosition - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationFactor);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiggleWithSpeed : MonoBehaviour
{
	private MeshRenderer rnderer;
	private Vector2 prevPos;
	private bool isStationary = true;
	public float stillSpeed = 3f;
	public float currentSpeed = 3f;
	public float swimmingSpeed = 8;

    // Start is called before the first frame update
    void Start()
    {
		currentSpeed = stillSpeed;
		rnderer = transform.GetChild (6).GetComponent<MeshRenderer> ();
		prevPos = new Vector2 (transform.position.x, transform.position.z);
	}

    // Update is called once per frame
    void Update()
    {
		Vector2 newPos = new Vector2 (transform.position.x, transform.position.z);
		float dist = Vector2.Distance (newPos, prevPos);

        if (dist <= 0.01 && !isStationary)
        {
            setSpeedTo(stillSpeed);
            isStationary = true;
        }
        else if (dist > 0.01 && isStationary)
        {
			setSpeedTo(swimmingSpeed);
			isStationary = false;
    }

    prevPos = newPos;
    }

	void setSpeedTo(float speed)
	{
		currentSpeed = speed;
		for (int i = 0; i < rnderer.materials.Length; i++) {
			
			rnderer.materials [i].SetFloat ("_WiggleSpeed", speed);
		}
	}
}

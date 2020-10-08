using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiggleWithSpeed : MonoBehaviour
{
	private MeshRenderer rnderer;
	private Vector2 prevPos;
	private bool isStationary = true;
	public float stillSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
		rnderer = transform.GetChild (6).GetComponent<MeshRenderer> ();
		prevPos = new Vector2 (transform.position.x, transform.position.z);
	}

    // Update is called once per frame
    void Update()
    {
		Vector2 newPos = new Vector2 (transform.position.x, transform.position.z);
		float dist = Vector2.Distance (newPos, prevPos);

		if (dist <= 0.01 && !isStationary) {
			setSpeedTo (stillSpeed);
			isStationary = true;
		} else if (dist > 0.01 && isStationary) {
			setSpeedTo (stillSpeed + (dist * 100f));
			isStationary = false;
		}

		prevPos = newPos;
    }

	void setSpeedTo(float speed)
	{
		for (int i = 0; i < rnderer.materials.Length; i++) {
			rnderer.materials [i].SetFloat ("_WiggleSpeed", speed);
		}
	}
}

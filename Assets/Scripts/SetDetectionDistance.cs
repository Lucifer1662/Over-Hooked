using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDetectionDistance : MonoBehaviour
{
	public FishSpawn spawner;
	public float newDistanceOfEffect = 4;

    // Start is called before the first frame update
    void Start()
    {
		spawner.fishSmall.GetComponent<moveTowards> ().distanceOfEffect = newDistanceOfEffect;
		spawner.fishMedium.GetComponent<moveTowards> ().distanceOfEffect = newDistanceOfEffect;
		spawner.fishLarge.GetComponent<moveTowards> ().distanceOfEffect = newDistanceOfEffect;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}

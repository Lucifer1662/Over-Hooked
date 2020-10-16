﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchFish : MonoBehaviour
{
    public Transform targetParent;
	public SpawnGameObject spawnChompSound;
	public ValueOfFish valueOfFish;

    public delegate void FishBitingHandler(object sender, Action e);

    public event FishBitingHandler fishBitingEvent;

    public void Start()
    {
        if (!targetParent)
            targetParent = transform;
		valueOfFish = GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<ValueOfFish> ();

		if (valueOfFish == null) {
			Debug.Log ("Please assign your player the 'Player' tag");
		}
    }

    public bool CatchesFish()
    {
        return true;
    }



    public void OnTriggerLeave(Collider other)
    {
        if (other.tag == "Fish")
        {
            if (CatchesFish())
            {
                fishBitingEvent(gameObject,
                    null
                   );
                //make you a child of the hook

                //might also want to disable movement script
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fish")
        {
			valueOfFish.pointToAdd = valueOfFish.GetValue (other.gameObject.name);

			// only spawn chomp sound in if there are no other chomp sounds
			if (GameObject.FindGameObjectsWithTag ("Chomp").Length == 0) {
				spawnChompSound.SpawnObject ();
			}

            if (CatchesFish())
            {
                fishBitingEvent(gameObject,
                    () =>
                    {
                        other.gameObject.transform.SetParent(targetParent);
                    }
                   );
                //make you a child of the hook

                //might also want to disable movement script
            }
        }
    }
}

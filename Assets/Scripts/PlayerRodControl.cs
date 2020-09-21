using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRodControl : MonoBehaviour
{
    public float castForce = 1;
    public float castDuration = 3;
    private float castPercent = 0;
    private float startTime;
    public GameObject lure;
    public Transform spawnPos;
    public float castAngle = 45.0f;
    public GameObject currentInstance = null;
    public Transform rod;

    bool isBeingHeldDown = false;


    bool Casting()
    {
        return isBeingHeldDown && currentInstance == null;
    }

    float percentageCasting()
    {
        if (Casting())
        {
            float duration = Time.time - startTime;
            duration = Math.Min(duration, castDuration);

            float percent = duration / castDuration;
            return percent;
        }
        else
        {
            return 0;
        }
    }

    private void Update()
    {
        float newRoadAnglex = Mathf.Lerp(0, -castAngle, percentageCasting());
        transform.eulerAngles = new Vector3(newRoadAnglex, transform.eulerAngles.y, transform.eulerAngles.z);
    }


    public void StartedCasting()
    {
        startTime = Time.time;

        if (currentInstance)
        {
            Destroy(currentInstance);
            currentInstance = null;
            isBeingHeldDown = false;
            isBeingHeldDown = false;
        }
        else
        {
            isBeingHeldDown = true;
        }
    }

    public void EndedCasting()
    {
        if (!isBeingHeldDown)
        {
            return;
        }


        float percent = percentageCasting();

        float force = percent * castForce;

        var instance = Instantiate(lure, spawnPos.position, Quaternion.identity);

        spawnPos.GetComponent<KeepLineAttachedTo>().to = instance.transform;

        currentInstance = instance;

        var rigid = instance.GetComponent<Rigidbody>();
        rigid.AddForce(force * Vector3.Normalize(transform.forward +
            Vector3.up * Mathf.Sin((castAngle / 180.0f) * Mathf.PI)));



        isBeingHeldDown = false;

    }
}

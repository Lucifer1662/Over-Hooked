using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchFish : MonoBehaviour
{
    public Transform targetParent;


    public delegate void FishBitingHandler(object sender, Action e);

    public event FishBitingHandler fishBitingEvent;

    public void Start()
    {
        if (!targetParent)
            targetParent = transform;
    }

    public bool CatchesFish()
    {
        return true;
    }



    public void OnTriggerLeave(Collider other)
    {
        OnTriggerStay(other);
    }

    public void OnTriggerEnter(Collider other)
    {
        OnTriggerStay(other);
    }


    public void OnTriggerStay(Collider other)
    {

        if (other.tag == "Fish")
        {
            if (CatchesFish())
            {
                fishBitingEvent.Invoke(gameObject,
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

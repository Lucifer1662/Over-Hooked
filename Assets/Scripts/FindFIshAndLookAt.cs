using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindFIshAndLookAt : MonoBehaviour
{

    public StickTo stickTo;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    Transform player;
    Vector3 playerOffset;
    private void OnEnable()
    {
        

        var fishes = GameObject.FindGameObjectsWithTag("Fish");
        float minDistance = Mathf.Infinity;
        GameObject closestFish = null;
        
        foreach (GameObject fish in fishes)
        {
            var distance = Vector3.Distance(transform.position, fish.transform.position);
            if (minDistance > distance)
            {
                minDistance = distance;
                closestFish = fish;
            }
        }

        if (closestFish)
        {
            player = stickTo.parent;
            player.GetComponent<PlayerController>().enabled = false;
            //playerOffset = stickTo.offset;
            stickTo.parent = closestFish.transform;
        }
    }

    private void OnDisable()
    {
        player.GetComponent<PlayerController>().enabled = true;
        stickTo.parent = player;
    }


}

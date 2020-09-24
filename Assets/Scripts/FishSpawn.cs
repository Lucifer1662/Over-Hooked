﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawn : MonoBehaviour
{
    public GameObject fishPrefab;
    public int maxFish;
    public float rangeLimit;
    public float islandSize;

    private int currentFish = 0;
    public float respawnPeriod = 3;
    private float respawnCountdown;


    // Start is called before the first frame update
    void Start()
    {
        GenerateFish();
        respawnCountdown = respawnPeriod;
    }

    // Update is called once per frame
    void Update()
    {
        respawnCountdown -= Time.deltaTime;
        if (respawnCountdown < 0.0f)
        {
            // Perform a single step to move the swarm across (or down)
            // Then reset the timer to periodically perform such steps
            GenerateFish();
            
            respawnCountdown = respawnPeriod;
        }
    }

    // Generate fishes until reaches max number of fish allowed
    void GenerateFish(){
        
        if(currentFish >= maxFish){
            return;
        }

        Vector3 fishPosition = GeneratePosition();

        GameObject newFish = Instantiate(fishPrefab, fishPosition, Quaternion.identity);
        newFish.transform.parent = this.transform;

        currentFish++;
    }

    // Generate random position outside of island
    Vector3 GeneratePosition(){
        Vector3 position;
        float randomX;
        float randomZ;

        // Random number for X and Z
        // Currently set Y as 0 for testing
        randomX = Random.Range(-rangeLimit, rangeLimit);
        while ((randomX < islandSize/2)  &&  (randomX > -islandSize/2))
        {
            randomX = Random.Range(-rangeLimit, rangeLimit);
        }

        randomZ = Random.Range(-rangeLimit, rangeLimit);
        while ((randomZ < islandSize/2)  &&  (randomZ > -islandSize/2))
        {
            randomZ = Random.Range(-rangeLimit, rangeLimit);
        }

        position.x = randomX;
        position.z = randomZ;
        position.y = transform.position.y;

        return position;
    }
}

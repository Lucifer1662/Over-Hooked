using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawn : MonoBehaviour
{
    public GameObject fishPrefab;
    public int maxFish;
    public float rangeLimit;
    //public float islandSize;

    private int currentFish = 0;
    public float respawnPeriod = 3;
    private float respawnCountdown;

    private RaycastHit hit;


    // Start is called before the first frame update
    void Start()
    {
        GenerateFish();
        respawnCountdown = respawnPeriod;
    }

    // Update is called once per frame
    void Update()
    {
        currentFish = transform.childCount;
        respawnCountdown -= Time.deltaTime;
        if (respawnCountdown < 0.0f)
        {
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
        
        while(determineTerrain(fishPosition)){
            fishPosition = GeneratePosition();
            Debug.Log("Hit the terrain, re-generate the fish position");
        }

        GameObject newFish = Instantiate(fishPrefab, fishPosition, Quaternion.Euler(GenerateRotation()));
        

        newFish.transform.parent = this.transform;
    }

    // Generate random position outside of island
    Vector3 GeneratePosition(){
        Vector3 position;
        float randomX;
        float randomZ;


        // Random number for X and Z
        // Currently set Y as 0 for testing
        randomX = Random.Range(-rangeLimit, rangeLimit);
        /*
        while ((randomX < islandSize/2)  &&  (randomX > -islandSize/2))
        {
            randomX = Random.Range(-rangeLimit, rangeLimit);
        }*/

        randomZ = Random.Range(-rangeLimit, rangeLimit);
        /*
        while ((randomZ < islandSize/2)  &&  (randomZ > -islandSize/2))
        {
            randomZ = Random.Range(-rangeLimit, rangeLimit);
        }*/

        position.x = randomX;
        position.z = randomZ;
        position.y = transform.position.y;

        return position;
    }

    
    // Gegenrate random rotation for every new fish
    private static Vector3 GenerateRotation()
    {
        float randomRotationY;
        randomRotationY = Random.Range(-180, 180);

        return new Vector3(0, randomRotationY, 0);
    }

    // Determine whether the spawn position is terrain 
    private bool determineTerrain(Vector3 newLocation)
    {
        bool terrain = false;

        Vector3 castLocation = new Vector3(newLocation.x, newLocation.y + 100, newLocation.z);

        if (Physics.Raycast(castLocation, newLocation - castLocation, out hit, 1000)){
            //Debug.Log("Found an object - distance: " + hit.distance);
        }
        
        // If distance is <100 then position is "inside" terrain
        if(hit.distance < 100){
            terrain = true;
        }

        return terrain;
    }
    
}

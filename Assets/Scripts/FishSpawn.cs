using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawn : MonoBehaviour
{
    public GameObject fishSmall;
    public GameObject fishMedium;
    public GameObject fishLarge;
    public int maxFish;
    private float rangeLimit = 50;

    private int currentFish = 0;
    public float respawnPeriod = 1;
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

        // Assign fish type
        int randomFish = Random.Range(0, 3);

        // Allocate spawn location
        Vector3 fishPosition = GeneratePosition(randomFish);
        int tries = 0;
        while(determineTerrain(fishPosition) && tries < 20){
            fishPosition = GeneratePosition(randomFish);
            tries++;
            //Debug.Log("Hit the terrain, re-generate the fish position");
        }
        
        // Instantiate new fish and attach movement script
        if (randomFish == 0){
            createFish(fishSmall, fishPosition);
        }else if (randomFish == 1){
            createFish(fishMedium, fishPosition);
        }else{
            createFish(fishLarge, fishPosition);
        }
        
	}

    // Instantiate fishes
    void createFish(GameObject fishSize, Vector3 fishPosition){
        GameObject newFish = Instantiate(fishSize, fishPosition, Quaternion.Euler(GenerateRotation()));
        newFish.transform.parent = this.transform;
        newFish.GetComponent<ChangeColour>();

    }

	// Generate position outside of island
    // According to different kinds of fish
	Vector3 GeneratePosition(int fishSize){
        Vector3 islandCentre = new Vector3(0f, 0f, 0f);
        Vector3 position = randomPosition();

        // Restricted distance for various kinds of fish
        if (fishSize == 0){
            while (Vector3.Distance(position, islandCentre) > 35 || Vector3.Distance(position, islandCentre) < 20){
                position = randomPosition();
            }
        }
        else if (fishSize == 1){
            while (Vector3.Distance(position, islandCentre) > 55 || Vector3.Distance(position, islandCentre) < 30){
                position = randomPosition();
            }
        }
        else {
            while (Vector3.Distance(position, islandCentre) < 45){
                position = randomPosition();
            }
        }

        return position;
    }

    // Just generate random positions
    Vector3 randomPosition(){
        Vector3 position;
        float randomX;
        float randomZ;

        // Random number for X and Z
        // Currently set Y as 0 for testing
        randomX = Random.Range(-rangeLimit, rangeLimit);
        randomZ = Random.Range(-rangeLimit, rangeLimit);

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

        Physics.Raycast(castLocation, newLocation - castLocation, out hit, 1000);
        
        // If distance is <100 then position is "inside" terrain
        if(hit.distance < 100){
            terrain = true;
        }

        return terrain;
    }
    
}

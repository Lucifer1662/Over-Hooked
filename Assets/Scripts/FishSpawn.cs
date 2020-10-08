using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawn : MonoBehaviour
{
    public GameObject fishSmall;
    public GameObject fishMedium;
    public GameObject fishLarge;
    public int maxFish;
    public float rangeLimit = 10;
    //public float islandSize;

    private int currentFish = 0;
    public float respawnPeriod = 1;
    private float respawnCountdown;

    private RaycastHit hit;
 
    
    Material mat;
    


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

        int tries = 0;
        while(determineTerrain(fishPosition) && tries < 20){
            fishPosition = GeneratePosition();
            tries++;
            //Debug.Log("Hit the terrain, re-generate the fish position");
        }
        
        // Instantiate new fish and attach movement script
        int randomFish = Random.Range(0, 3);
        if (randomFish == 0){
            createFish(fishSmall, fishPosition);
        }else if (randomFish == 1){
            createFish(fishMedium, fishPosition);
        }else{
            createFish(fishLarge, fishPosition);
        }
        
        
        // newFish.GetComponent<ChangeScale>();

	}

    void createFish(GameObject fishSize, Vector3 fishPosition){
        GameObject newFish = Instantiate(fishSize, fishPosition, Quaternion.Euler(GenerateRotation()));
        newFish.transform.parent = this.transform;
        newFish.GetComponent<ChangeColour>();

    }

	// Generate random position outside of island
	Vector3 GeneratePosition(){
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

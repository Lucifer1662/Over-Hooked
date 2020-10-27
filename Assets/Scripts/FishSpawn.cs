using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishSpawn : MonoBehaviour
{
    public GameObject fishSmall;
    public GameObject fishMedium;
    public GameObject fishLarge;
    public int maxFish;
    private float rangeLimit = 60;
    private float landSize;

    private int currentFish = 0;
    public float respawnPeriod = 1;
    private float respawnCountdown;

    private RaycastHit hit;


    [Range(0, 20)]
    public int mediumFishLimit;
    [Range(0, 20)]
    public int largeFishLimit;

    private int smallFishNumber = 0;
    private int mediumFishNumber = 0;
    private int largeFishNumber = 0;



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
        const int maxTries = 10;
        while(determineTerrain(fishPosition) && tries < maxTries){
            fishPosition = GeneratePosition(randomFish);
            tries++;
        }
        if (tries >= maxTries) {
            return;
        }
        
        // Check fish number limit for its type
        // Instantiate new fish
        if ((randomFish == 2) && (++largeFishNumber <= largeFishLimit)){
            createFish(fishLarge, fishPosition);
            //Debug.Log("current large fish number is: " + largeFishNumber + " --- large fish number limit is: " + largeFishLimit);
        }else if ((randomFish == 1) && (++mediumFishNumber <= mediumFishLimit)){
            createFish(fishMedium, fishPosition);
            //Debug.Log("current medium fish number is: " + mediumFishNumber + " --- medium fish number limit is: " + mediumFishLimit);
        }else{
            createFish(fishSmall, fishPosition);
            smallFishNumber++;
            //Debug.Log("current small fish number is: " + smallFishNumber);
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
        Scene scene = SceneManager.GetActiveScene();
        Vector3 islandCentre = new Vector3(0f, 0f, 0f);
        Vector3 position = randomPosition();
        
        if (scene.name == "Level 2") {
            landSize = 10;
        }else {
            landSize = 25;
        }
        float validRange = rangeLimit - landSize;

        // Restricted distance for various kinds of fish
        if (fishSize == 0){
            while (Vector3.Distance(position, islandCentre) > (landSize + validRange * 0.3) || Vector3.Distance(position, islandCentre) < landSize){
                position = randomPosition();
            }
        }
        else if (fishSize == 1){
            while (Vector3.Distance(position, islandCentre) > (landSize + validRange / 2 + validRange * 0.3) || Vector3.Distance(position, islandCentre) < (landSize + validRange / 2 - validRange * 0.3)){
                position = randomPosition();
            }
        }
        else {
            while (Vector3.Distance(position, islandCentre) < (landSize + validRange / 2 + validRange * 0.2)){
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

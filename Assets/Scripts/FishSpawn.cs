using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawn : MonoBehaviour
{
    public GameObject fishPrefab;
    public int maxFish;
    public float rangeLimit = 10;
    //public float islandSize;

    private int currentFish = 0;
    public float respawnPeriod = 1;
    private float respawnCountdown;

    private RaycastHit hit;
    private Color[] colors = {new Color(0.9803922f, 0.5019608f, 0.4509804f),
							new Color (1f, 0.627451f, 0.482353f),
							new Color (0.9843138f, 0.6980392f, 0.5490196f),
							new Color (0.872f, 0.174242f, 0.160448f)};
    private int randomColour;
    Material mat;
    private int rndColor;


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
        GameObject newFish = Instantiate(fishPrefab, fishPosition, Quaternion.Euler(GenerateRotation()));
        newFish.transform.parent = this.transform;
        int lengthOfColors = colors.Length;  
        rndColor = Random.Range(0, lengthOfColors);
		
		newFish.transform.GetChild(6).GetComponent<MeshRenderer> ().materials [0].color = colors [rndColor];
		newFish.transform.GetChild (6).GetComponent<MeshRenderer> ().materials [1].color = new Color (colors [rndColor].r, colors [rndColor].g + 0.2f, colors [rndColor].b + 0.2f);
        newFish.GetComponent<ChangeScale>();

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

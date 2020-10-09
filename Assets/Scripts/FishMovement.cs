using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{

    private float initialTick = 6;
    private float tickCountdown;

    public float speed = 3;
    private Vector3 direction;
    private Vector3 newPosition;

    private Vector3 spawnLocation;
    private float range = 15;

    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        // Store spawning location
        spawnLocation = transform.position;

        // No need to change direction for the first time
        tickCountdown = initialTick;
        newPosition = this.transform.position + this.transform.forward * 5;
        direction = transform.rotation.eulerAngles;
    }


    void Update()
    {
        // Time's up, change new direction
        tickCountdown -= Time.deltaTime;
        if (tickCountdown < 0.0f)
        {
            initialTick = Random.Range(6, 10);
            tickCountdown = initialTick;
            
            newPosition = GenerateNewPosition(); 
        }
        
        // Move after each direction change 
        // And pause for 1/3 tick time
        else if (tickCountdown > initialTick/3){
            move(speed, newPosition);
        }

    }

    // Gradually rotate
    void changeDirection(Vector3 newRotation){
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(newRotation), Time.deltaTime*3);
    }

    // Set new movement direction
    private static Vector3 GenerateRotation()
    {
        float randomRotationY;
        randomRotationY = Random.Range(-180, 180);

        return new Vector3(0, randomRotationY, 0);
    }

    // Set random speed to make the movement more natural
    private static float GenerateSpeed()
    {
        float randomSpeed;
        randomSpeed = Random.Range(1, 5);

        return randomSpeed;
    }

    // Generate next valid position
    private Vector3 GenerateNewPosition(){
        direction = GenerateRotation();
        speed = GenerateSpeed();
        Vector3 newPosition = this.transform.position + (Quaternion.Euler(direction) * Vector3.forward) * speed * (initialTick - initialTick/3);
        
        // Avoid island and stay within the given range
        while ((determineTerrain(newPosition) == true) || (outsideRange(spawnLocation, newPosition, range) == true)){
            direction = GenerateRotation();
            speed = GenerateSpeed();
            newPosition = this.transform.position + (Quaternion.Euler(direction) * Vector3.forward) * speed * (initialTick - initialTick/3);
        }

        return newPosition;
    }


    // Move along the new direction
    void move(float speed, Vector3 newPosition){

        changeDirection(direction);
        transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
    }




    // Determine whether the new position is terrain 
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
            //Debug.Log("New position is terrain - raycast distance: " + hit.distance);
        }

        return terrain;
    }

    // Check whether the new position is outside restricted range 
    private bool outsideRange(Vector3 spawnLocation, Vector3 newLocation, float range){
        bool outside = false;

        if ((newLocation.x > spawnLocation.x+range) || (newLocation.x < spawnLocation.x-range))
        {
            return outside = true;
        }
        else if ((newLocation.z > spawnLocation.z+range) || (newLocation.z < spawnLocation.z-range))
        {
            return outside = true;
        }

        return outside;
    }
}

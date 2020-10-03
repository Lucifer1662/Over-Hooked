﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{

    private float initialTick = 3;
    private float tickCountdown;

    public float speed = 5;
    private Vector3 direction;

    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        // No need to change direction for the first time
        tickCountdown = initialTick;
    }


    void Update()
    {
        // Time's up, change new direction
        tickCountdown -= Time.deltaTime;
        if (tickCountdown < 0.0f)
        {
            tickCountdown = Random.Range(3, 7);
            direction = GenerateRotation();
            speed = GenerateSpeed();
            this.transform.rotation = Quaternion.Euler(direction);
            
        }
        move(speed);
        
    }


    // Set new movement direction
    private static Vector3 GenerateRotation()
    {
        float randomRotationY;
        randomRotationY = Random.Range(-180, 180);

        return new Vector3(0, randomRotationY, 0);
    }

    // select random speed to make the movement more natural
    private static float GenerateSpeed()
    {
        float randomSpeed;
        randomSpeed = Random.Range(3, 7);

        return randomSpeed;
    }

    // Move along the new direction
    void move(float speed){

        // Change direction to avoid terrain
        Vector3 newPosition = this.transform.position + this.transform.forward * 5;
        while (determineTerrain(newPosition) == true){
            //Debug.Log("Hit, current position is: " + transform.position + " increment position is: " + this.transform.forward * 5 + " new position is: " + newPosition);
            
            direction = GenerateRotation();
            speed = GenerateSpeed();
            this.transform.rotation = Quaternion.Euler(direction);
            newPosition = this.transform.position + this.transform.forward * speed * 5;
        }

        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
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
}

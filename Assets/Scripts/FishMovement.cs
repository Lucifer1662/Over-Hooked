using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{

    private float initialTick = 3;
    private float tickCountdown;

    public float speed;
    private Vector3 direction;

    

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
            tickCountdown = Random.Range(1, 5);
            direction = GenerateRotation();
            speed = GenerateSpeed();
            this.transform.rotation = Quaternion.Euler(direction);
            
        }
        // Otherwise continue moving along the old direction
        else{
            move(speed);
        }
        
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
        randomSpeed = Random.Range(3, 10);

        return randomSpeed;
    }

    // Move along the new direction
    void move(float speed){
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}

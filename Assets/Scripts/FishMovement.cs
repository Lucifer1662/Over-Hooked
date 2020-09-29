using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FishMovement : MonoBehaviour
{

    public float movementTick = 3;
    private float tickCountdown;

    public float speed;
    private Vector3 direction;

    

    // Start is called before the first frame update
    void Start()
    {
        // No need to change direction for the first time
        tickCountdown = movementTick;
    }


    void Update()
    {
        // Time's up, change new direction
        tickCountdown -= Time.deltaTime;
        if (tickCountdown < 0.0f)
        {
            direction = GenerateRotation();
            this.transform.rotation = Quaternion.Euler(direction);
            tickCountdown = movementTick;
        }
        // Otherwise continue moving along the old direction
        else{
            move();
        }
        
    }


    // Set new movement direction
    private static Vector3 GenerateRotation()
    {
        float randomRotationY;
        randomRotationY = Random.Range(-180, 180);

        return new Vector3(0, randomRotationY, 0);
    }

    // Move along the new direction
    void move(){
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}

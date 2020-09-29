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
        
    }

    // Update is called once per frame
    void Update()
    {
        tickCountdown -= Time.deltaTime;
        if (tickCountdown < 0.0f)
        {
            move(direction);
            direction = GenerateRotation();
            this.transform.rotation = Quaternion.Euler(direction);
            
            tickCountdown = movementTick;
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
    void move(Vector3 direction){
        //float currentX = this.transform.position.x;
        //float currentZ = this.transform.position.z;

        this.transform.Translate(Vector3.forward * speed);
    }
}

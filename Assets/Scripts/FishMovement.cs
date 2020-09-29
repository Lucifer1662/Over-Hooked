using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FishMovement : MonoBehaviour
{

    public float movementTick = 3;
    private float tickCountdown;

    public float maxDistance;
    private Vector3 target;
    private NavMeshAgent nav;

    

    // Start is called before the first frame update
    void Start()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        tickCountdown -= Time.deltaTime;
        if (tickCountdown < 0.0f)
        {
            
            move();
            tickCountdown = movementTick;
        }
    }

    void move(){
        float currentX = this.transform.position.x;
        float currentZ = this.transform.position.z;

        float newX = currentX + Random.Range(-maxDistance, maxDistance);
        float newZ = currentZ + Random.Range(-maxDistance, maxDistance);

        target = new Vector3 (newX, this.transform.position.y, newZ);

        nav.SetDestination(target);
    }
}

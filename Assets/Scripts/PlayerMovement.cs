using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int playerNumber = 0;
    public float speed = 1;

    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    public void Move(Vector3 direction) {
        direction.Normalize();
        rigidbody.MovePosition(transform.position + direction * Time.deltaTime * speed);
    }

    public void Look(Vector3 lookDirection) {
        transform.LookAt(transform.position + lookDirection, Vector3.up);
    }
}

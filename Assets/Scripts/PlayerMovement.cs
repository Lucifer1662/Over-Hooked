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

    // Update is called once per frame
    void Update()
    {

  
        Vector3 lookDirection = new Vector3(Input.GetAxis("HorizontalLook" + playerNumber),0, Input.GetAxis("VerticalLook" + playerNumber));

        transform.LookAt(transform.position + lookDirection, Vector3.up);


      
    }

    public void Move(Vector3 direction) {
        rigidbody.MovePosition(transform.position + direction * Time.deltaTime * speed);
    }
}

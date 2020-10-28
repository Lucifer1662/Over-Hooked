using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelBack : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        var d = Input.GetAxis("Mouse ScrollWheel") * 5.0f;
        rb.drag = 1;
        //scroll down
        if (d < 0f)
        {
            GameObject player = GameObject.FindWithTag("Player");
            var movingDirection = player.transform.position;
            movingDirection.y = -0.2f;
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            Mathf.Clamp(transform.position.y, 0.2f, 10f);
            rb.AddForce((player.transform.position - transform.position).normalized * -d);
        }

        var pos = transform.position;
        pos.y = 0.4f;
        transform.position = pos;
    }
}

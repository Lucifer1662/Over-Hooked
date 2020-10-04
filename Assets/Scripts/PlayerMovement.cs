using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int playerNumber = 0;
    public float speed = 1;
    public float Sensitivity;

    private new Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    public void Move(Vector3 direction) {
        direction.Normalize();
        if(isActiveAndEnabled)
            rigidbody.MovePosition(transform.position + direction * Time.deltaTime * speed);
    }

    public void Look(Vector3 lookDirection) {
        if (isActiveAndEnabled)
            transform.LookAt(transform.position + lookDirection, Vector3.up);
    }

    public void LookDelta() {
        Cursor.lockState = CursorLockMode.Locked;
        var mouse = new Vector2(Input.GetAxisRaw("Mouse X"), -Input.GetAxisRaw("Mouse Y"));
        mouse = new Vector3(mouse.y * Sensitivity, mouse.x * Sensitivity, 0);
        mouse = new Vector3(transform.eulerAngles.x + mouse.x, transform.eulerAngles.y + mouse.y, 0);

        //clamp the viewing angle to a range, preventing camera to flip
        if (mouse.x > 90 && mouse.x < 180)
        {
            mouse.x = 90;
        }
        else if (mouse.x < 270 && mouse.x > 180)
        {
            mouse.x = 270;
        }
        transform.eulerAngles = mouse;
    }
}

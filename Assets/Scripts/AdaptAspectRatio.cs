using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptAspectRatio : MonoBehaviour
{
    public float transitionTime = 25;
    private Vector3 startPos;
    private Vector3 endPos;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Check current window size 
        float width = Screen.width;
        float height = Screen.height;
        //Debug.Log("width is: " + width);
        //Debug.Log("height is: " + height);

        // Set position under screen
        transform.localPosition = new Vector3(transform.localPosition.x, -height, transform.localPosition.z);
        // Set start and end position
        startPos = transform.localPosition;
        endPos = new Vector3(transform.localPosition.x, height, transform.localPosition.z);

    }

    // Update is called once per frame
    void Update()
    {
        transitionTime -= Time.deltaTime;
        timer += Time.deltaTime/transitionTime;
        // Perform credit transition
        if (transitionTime > 0) {
            transform.localPosition = Vector3.Lerp(startPos, endPos, timer);
        }
    }

}

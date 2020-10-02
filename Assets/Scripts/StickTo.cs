using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickTo : MonoBehaviour
{
    public Transform parent;
    private Vector3 offset;
    public Vector3 extraOffset;
    public float lerpSpeed = 0.5f;
    public float extraLerpSpeed = 0.5f;
    private Vector3 currentTargetOffset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - parent.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentTargetOffset = Vector3.Lerp(currentTargetOffset, extraOffset, extraLerpSpeed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, parent.position  + currentTargetOffset + offset, lerpSpeed * Time.deltaTime);
    }
}

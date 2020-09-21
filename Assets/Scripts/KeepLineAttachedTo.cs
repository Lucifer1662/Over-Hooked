using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepLineAttachedTo : MonoBehaviour
{
    LineRenderer line;
    public Transform to;
    public Transform from;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!from)
            from = transform;

        line.SetPosition(0, from.position);

        if (to)
            line.SetPosition(1, to.position);
        else
            line.SetPosition(1, from.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScale : MonoBehaviour
{

    private Vector3 scaleChange;
    // Start is called before the first frame update
    void Start()
    {
        float randomSize = Random.Range(-0.1f, 0.3f);
        scaleChange = new Vector3(randomSize, randomSize, randomSize);
        transform.localScale += scaleChange;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(waitfor());
        
        
        

        
    }
    void Update(){
        
        
    }
    IEnumerator waitfor(){
        
        rb.AddForce(0,0,10,ForceMode.Impulse);
        yield return new WaitForSeconds(3);
        rb.AddForce(0,0,-10,ForceMode.Impulse);


    }
}

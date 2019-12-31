using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiisionDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void OnCollisionEnter(Collision collided)
    {
        
        if (collided.gameObject.tag == "theTagWeWant")
        {
            //dostuff
            //
        }
    }
}
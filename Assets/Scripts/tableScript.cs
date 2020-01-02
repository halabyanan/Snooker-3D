using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tableScript : MonoBehaviour
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

        if (collided.gameObject.name == "CueBall")
        {
            //    Physics.gravity = new Vector3(0f, 0f, 0f);
            //      rb.AddForce((GameObject.Find("table").transform.position - transform.position).normalized * 10);
            //dostuff
        }

    }

}

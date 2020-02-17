using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;


public class BotenTbleController : MonoBehaviour
{
    public GameObject redBalls;

    // Start is called before the first frame update
    void Start()
    {
        redBalls = GameObject.Find("RedBalls");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {

        foreach (var rigidbody in redBalls.GetComponentsInChildren<Rigidbody>())
           
        {
            if (rigidbody.transform.name == collision.gameObject.name)
            {
                
           //   Thread a = new Thread(()=>AddNormalForce(collision,rigidbody));
          //    a.Start();
                rigidbody.AddForce(collision.contacts[0].normal - rigidbody.transform.position);
              
            }
        }

    }

  /*  public static void AddNormalForce(Collision collision,Rigidbody rigidbody)
    {
        rigidbody.AddForce(collision.contacts[0].normal - rigidbody.transform.position);
    }
    */

}

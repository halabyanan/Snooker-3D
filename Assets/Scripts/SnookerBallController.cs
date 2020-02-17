using UnityEngine;
using System.Collections;

public class SnookerBallController : MonoBehaviour
{
    public GameObject redBalls;
    public GameObject cueBall ;
    private Rigidbody rb;
    Vector3 center = new Vector3(-112,98,-16);
    private int flag = 0 ;
   /* public SnookerBallController(MonoBehaviour parent)
        : base(parent)
    {
        gameController = (PoolGameController)parent;
        redBalls = gameController.redBalls;
    }*/
	void Start() {
        rb = GetComponent<Rigidbody>();
        rb.sleepThreshold = 0.15f;


        
       
	}

    void OnCollisionEnter(Collision collided)
    {
        
  
    }

	void FixedUpdate () {

        var rigidbody = GetComponent<Rigidbody>();
        if (rigidbody.velocity.y > 0)
        {
            var velocity = rigidbody.velocity;

            
       
            velocity.y *= 1.02f;
            //  velocity.x *= 0.2f;
            rigidbody.velocity = velocity;
        }

        if (rigidbody.velocity.x > 0)
        {
            var velocity = rigidbody.velocity;
           

  
            
            velocity.x *= 1.02f;
            //  velocity.x *= 0.2f;
            rigidbody.velocity = velocity;
        }

        if (rigidbody.velocity.z > 0)
        {
            var velocity = rigidbody.velocity;


            velocity.z *= 1.02f;
            //  velocity.x *= 0.2f;
            rigidbody.velocity = velocity;
        }
	}
}

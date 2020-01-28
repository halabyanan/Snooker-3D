using UnityEngine;
using System.Collections;
using System.Threading;
using System.Timers;
using System;
using System.Collections.Generic;
using System.Collections;
namespace GameStates {
	public class WaitingForNextTurnState : AbstractGameObjectState {
		private PoolGameController gameController;
		private GameObject cue;
		private GameObject cueBall;
		private GameObject redBalls;
		private GameObject mainCamera;
        private GameObject botenwithholes;
        int flagTimer = 0;
        int flag = 0;
		private Vector3 cameraOffset;
		private Quaternion cameraRotation;
		private Vector3 cueOffset;
		private Quaternion cueRotation;
        private int time = 0;
      //  private int X1 = 40, X2 = -28, Z1 = 70, Z2 = -80;
        private Vector3 originalCueBallPosition;
        private int cueBallBeginPosition = 0;
        private Vector3 begingPositin  = new Vector3();            

        private static System.Timers.Timer aTimer;
		public WaitingForNextTurnState(MonoBehaviour parent) : base(parent) {
			gameController = (PoolGameController)parent;
         
            botenwithholes = gameController.botenWithHoles;
           
			cue = gameController.cue;
			cueBall = gameController.cueBall;
			redBalls = gameController.redBalls;
			mainCamera = gameController.mainCamera;
            originalCueBallPosition = cueBall.transform.position;
			cameraOffset = cueBall.transform.position - mainCamera.transform.position;
			cameraRotation = mainCamera.transform.rotation;
			cueOffset = cueBall.transform.position - cue.transform.position;
			cueRotation = cue.transform.rotation;
		}
        private void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private  void OnTimedEvent(System.Object source, ElapsedEventArgs e)
        {
            time++;

        }

		public override void FixedUpdate() {
            flag = 1;
           // Collider col;
			Debug.Log(redBalls.GetComponentsInChildren<Transform>().Length);
			if (redBalls.GetComponentsInChildren<Transform>().Length == 1) {
                gameController.EndMatch();
			} else {
                                               
                	var cueBallBody = cueBall.GetComponent<Rigidbody>();
            //        cueBallBody.useGravity = true;
             

                   
                    if (flagTimer == 0)
                    {
                        SetTimer();
                        flagTimer = 1;
                    }
                    if (time == 2)
                    {
                        cueBallBody.useGravity = false;
                        cueBallBody.velocity = Vector3.zero;
                        
                        time = 0;
                        flagTimer = 0;
                        
                    }



    


                //////////
                  //  var dir = gameController.strikeDirection * -1;
                   // var vec3 = Vector3(0, 0, -1);

                    /*            if (cueBallBody.position.z < Z2 || cueBallBody.position.z > Z1 || cueBallBody.position.x < X2 || cueBallBody.position.x > X1)
                                {

                                    cueBallBody.transform.position = new Vector3(0.01f, -4.98f, 4.77f);
                                    cueBallBody.velocity = Vector3.zero;

                                    mainCamera.transform.position = cueBall.transform.position - cameraOffset;
                                    mainCamera.transform.rotation = cameraRotation;

                                    cue.transform.position = cueBall.transform.position - cueOffset;
                                    cue.transform.rotation = cueRotation;
                                    cueBallBody.useGravity = false;

                                }
                     * */
                    if (!(cueBallBody.IsSleeping() || cueBallBody.velocity == Vector3.zero))
                         return;


                     /*foreach (var rigidbody in redBalls.GetComponentsInChildren<Rigidbody>())
                    {
                        if (!(rigidbody.IsSleeping() || rigidbody.velocity == Vector3.zero))////// פה הבעיה !! הם ממשיכים לנוע לכן התור לא ממשיך !!
                            return;
                    }
                */
                    

				gameController.NextPlayer();
				// If all balls are sleeping, time for the next turn
				//
				gameController.currentState = new WaitingForStrikeState(gameController);
			}
		}


        public override void Update()
        {

            var cueBallBody = cueBall.GetComponent<Rigidbody>();



            Collider col = botenwithholes.GetComponent<Collider>();


            foreach (var rigidbody in redBalls.GetComponentsInChildren<Rigidbody>())
            {

                Vector3 closestPoint = col.ClosestPointOnBounds(rigidbody.position);
                rigidbody.AddForce(closestPoint - rigidbody.transform.position);
                //    rigidbody.MovePosition(closestPoint - rigidbody.transform.position);


            }

            Vector3 closestPointOfWhiteBall = col.ClosestPointOnBounds(cueBallBody.position);
            cueBallBody.AddForce(closestPointOfWhiteBall - cueBallBody.transform.position);
         
        }
   /*     private void CheckRangeOfCueBall(Rigidbody cueBallBody)
        {
            if (cueBallBody.position.z < Z2 || cueBallBody.position.z > Z1 || cueBallBody.position.x < X2 || cueBallBody.position.x > X1)
                    {
                        
                        cueBallBody.transform.position = new Vector3( 0.0f , 1.88f , 6.21f);
                        cueBallBody.velocity = Vector3.zero;

                        mainCamera.transform.position = cueBall.transform.position - cameraOffset;
                        mainCamera.transform.rotation = cameraRotation;

                        cue.transform.position = cueBall.transform.position - cueOffset;
                        cue.transform.rotation = cueRotation;
                       // cueBallBody.useGravity = false;
                        cueBallBody.velocity = Vector3.zero;
                    }
            

        }*/

       
		public override void LateUpdate() {

          //  RedBallsCont redBallCont = new RedBallsCont();
          //  List<GameObject> list = redBallCont.GetAllChilds();

          
                flag = 1;
           
    /*        foreach (var obj in list)
            {

                Vector3 closestPoint = col.ClosestPointOnBounds(obj.transform.position);
             //   var go = obj.gameobject;
                obj.GetComponent<Rigidbody>().AddForce(closestPoint - obj.transform.position);
               // go.AddForce(closestPoint - rigidbody.transform.position);
             //   obj.MovePosition(closestPoint - obj.position);


            }
      */
			mainCamera.transform.position = cueBall.transform.position - cameraOffset;
			mainCamera.transform.rotation = cameraRotation;
			
			cue.transform.position = cueBall.transform.position - cueOffset;
			cue.transform.rotation = cueRotation;
            
            
		}
	}
}
using UnityEngine;
using System.Collections;
using System.Threading;
using System.Timers;
using System;
namespace GameStates {
	public class WaitingForNextTurnState : AbstractGameObjectState {
		private PoolGameController gameController;
		private GameObject cue;
		private GameObject cueBall;
		private GameObject redBalls;
		private GameObject mainCamera;
        private GameObject table;
        int flagTimer = 0;
		private Vector3 cameraOffset;
		private Vector3 cueOffset;
		private Quaternion cameraRotation;
		private Quaternion cueRotation;
        private int time = 0;
      //  private int X1 = 40, X2 = -28, Z1 = 70, Z2 = -80;
        private Vector3 originalCueBallPosition;
        private int cueBallBeginPosition = 0;
        private Vector3 begingPositin  = new Vector3();            

        private static System.Timers.Timer aTimer;
		public WaitingForNextTurnState(MonoBehaviour parent) : base(parent) {
			gameController = (PoolGameController)parent;

            table = gameController.table;
           
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
            aTimer = new System.Timers.Timer(2000);
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
            
			Debug.Log(redBalls.GetComponentsInChildren<Transform>().Length);
			if (redBalls.GetComponentsInChildren<Transform>().Length == 1) {
                gameController.EndMatch();
			} else {
                                               
                	var cueBallBody = cueBall.GetComponent<Rigidbody>();
                    cueBallBody.useGravity = true;
               //     CheckRangeOfCueBall(cueBallBody);
               //    var cueBallBodyret =  CheckIfToLetGravity(cueBallBody);
                ////////////// checking the gravity time

                   
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
                
                       /*   foreach (var rigidbody in redBalls.GetComponentsInChildren<Rigidbody>()) {
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

        private Rigidbody CheckIfToLetGravity(Rigidbody cueBallBody)
        {
            if (flagTimer == 0 )
            {
                SetTimer();
                flagTimer = 1;
            }
            
            
            if (time == 1)
            {
                cueBallBody.useGravity = false;
                time = 0;
            }
            return cueBallBody;
        }
       
		public override void LateUpdate() {
			mainCamera.transform.position = cueBall.transform.position - cameraOffset;
			mainCamera.transform.rotation = cameraRotation;
			
			cue.transform.position = cueBall.transform.position - cueOffset;
			cue.transform.rotation = cueRotation;
            
            
		}
	}
}
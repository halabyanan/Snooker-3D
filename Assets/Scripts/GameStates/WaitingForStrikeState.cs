using UnityEngine;
using System.Collections;

namespace GameStates {
	public class WaitingForStrikeState  : AbstractGameObjectState {
		private GameObject cue;
		private GameObject cueBall;
		private GameObject mainCamera;

		private PoolGameController gameController;

		public WaitingForStrikeState(MonoBehaviour parent) : base(parent) { 
			gameController = (PoolGameController)parent;
			cue = gameController.cue;
			cueBall = gameController.cueBall;
			mainCamera = gameController.mainCamera;

			cue.GetComponent<Renderer>().enabled = true;
		}

		public override void Update() {
			var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");

            if (y != 0)
            {
                var angle = y * 100 * Time.deltaTime;
                gameController.strikeDirection = Quaternion.AngleAxis(angle, Vector3.right) * gameController.strikeDirection;
                mainCamera.transform.RotateAround(cueBall.transform.position, Vector3.right, angle);
                cue.transform.RotateAround(cueBall.transform.position, Vector3.right, angle);
            }


			if (x != 0) {
				var angle = x * 100 * Time.deltaTime;
				gameController.strikeDirection = Quaternion.AngleAxis(angle, Vector3.up) * gameController.strikeDirection;
				mainCamera.transform.RotateAround(cueBall.transform.position, Vector3.up, angle);
				cue.transform.RotateAround(cueBall.transform.position, Vector3.up, angle);
			}
			Debug.DrawLine(cueBall.transform.position, cueBall.transform.position + gameController.strikeDirection * 10);

			if (Input.GetButtonDown("Fire1")) {
				gameController.currentState = new GameStates.StrikingState(gameController);
			}
		}
	}
}
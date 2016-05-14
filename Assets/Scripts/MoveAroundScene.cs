using UnityEngine;
using System.Collections;
using Leap;

public class MoveAroundScene : MonoBehaviour {

	public Transform myCamera;
	public float speed;
	bool spotTouched = false;

	public HandModel hand_model;
	Hand leap_hand;


	Controller controller;

	void Start() {
		controller = new Controller ();
		controller.EnableGesture (Gesture.GestureType.TYPESCREENTAP);

		hand_model = GetComponent<HandModel> ();
		leap_hand = hand_model.GetLeapHand ();
	}
	void Update() {
		Frame frame = controller.Frame();
		GestureList gestures = frame.Gestures();
		Vector3 positionToMove = new Vector3 ();
		for (int i = 0; i < gestures.Count; ++i) {
			if (gestures[i].Type == Gesture.GestureType.TYPESCREENTAP) {
				ScreenTapGesture gesture = new ScreenTapGesture (gestures[i]);
				/*
				Vector3 direction = new Vector3 ();
				direction.x = gesture.Direction.x;
				direction.y = gesture.Direction.y;
				direction.z = gesture.Direction.z;

				Vector3 origin = new Vector3 ();
				origin.x = gesture.Position.x;
				origin.y = gesture.Position.y;
				origin.z = gesture.Position.z;

				Ray ray = new Ray (origin, direction);

				RaycastHit hit;
				if (Physics.Raycast (ray, out hit)) {
					Debug.Log ("HITTING!! " + hit.collider.name);
					if (hit.collider.tag == "spot") {
						positionToMove = hit.transform.position;
						spotTouched = true;

					}
				}*/
			}
		}
		if (spotTouched){
			float step = speed * Time.deltaTime;
			myCamera.position = Vector3.MoveTowards(myCamera.position, positionToMove, step);
			if (myCamera.position == transform.position) {
				spotTouched = false;
			}
		}
	}
}

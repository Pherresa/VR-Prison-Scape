using UnityEngine;
using System.Collections;
using Leap;

public class Gestures : MonoBehaviour {

	public Transform myCamera;
	public float speed = 10;

	Controller controller;

	HandModel hand_model;
	Hand leap_hand;

	private bool spotTouched = false;

	void Start() {

		// Camera rotation gestures
		controller = new Controller ();
		controller.EnableGesture (Gesture.GestureType.TYPESWIPE);
		controller.Config.SetFloat ("Gesture.Swipe.MinLength", 200.0f);
		controller.Config.SetFloat ("Gesture.Swipe.MinVelocity", 600f);


		// Movement gestures
		hand_model = GetComponent<HandModel> ();
		leap_hand = hand_model.GetLeapHand ();
		controller.EnableGesture (Gesture.GestureType.TYPESCREENTAP);
		if (leap_hand == null)
			Debug.Log ("Leap Hand Model not FOund");

	}
	Vector3 positionToMove ;
	void Update() {
		
		FingerModel finger = hand_model.fingers[1];
		// draw ray from finger tips (enable Gizmos in Game window to see)
		Debug.DrawRay(finger.GetTipPosition(), finger.GetRay().direction, Color.red); 
	
		Frame frame = controller.Frame();
		GestureList gestures = frame.Gestures();

		for (int i = 0; i < gestures.Count; ++i) {
			if (!spotTouched) {
				if (gestures [i].Type == Gesture.GestureType.TYPESCREENTAP) {
					ScreenTapGesture gesture = new ScreenTapGesture (gestures [i]);

					Ray ray = new Ray (finger.GetTipPosition (), finger.GetRay ().direction);

					RaycastHit hit;
					if (Physics.Raycast (ray, out hit)) {
						print ("HITTING!! " + hit.collider.name);
						if (hit.collider.tag == "spot") {
							Debug.Log ("POS: " + hit.collider.transform.position);
							positionToMove = hit.collider.transform.position;
							spotTouched = true;

						}
					}
				} else if (gestures [i].Type == Gesture.GestureType.TYPESWIPE) {
					SwipeGesture gesture = new SwipeGesture (gestures [i]);
					Vector swipeDirection = gesture.Direction;
					if (swipeDirection.x > 0) {
						myCamera.Rotate (new Vector3 (0, 2, 0));
					} else if (swipeDirection.x <= 0) {
						myCamera.Rotate (new Vector3 (0, -2, 0));
					}
				}
			}
		}
		if (spotTouched){
			float step = speed * Time.deltaTime;
			myCamera.position = Vector3.MoveTowards(myCamera.position, positionToMove, step);
			if (myCamera.position == positionToMove) {
				spotTouched = false;
			}
		}
	}
}

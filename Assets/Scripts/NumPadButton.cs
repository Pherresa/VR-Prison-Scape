using UnityEngine;
using System.Collections;
using Leap;

public class NumPadButton : MonoBehaviour {
	
	public int value;
	bool hasBeenRecentlyTouched = false;
	
	public LockScreen screen;
	
	void Start() {
	}
	
	void Update() {
	}
	
	void OnTriggerEnter(Collider other) {
		StartCoroutine(Triggered());
	}
	
	void OnMouseDown(){
		Debug.Log(value.ToString());
		StartCoroutine(Triggered());
	}
	
	IEnumerator Triggered(){
		if ((!hasBeenRecentlyTouched) && (screen.addingValue == -1)){
			if (value < 0){
				// Clearing code
				screen.clear = 1;
			} else {
				screen.addingValue = value;
			}
			hasBeenRecentlyTouched = true;
			yield return new WaitForSeconds(2);
			hasBeenRecentlyTouched= false;
		}
	}
}
using UnityEngine;
using System.Collections;

public class MoveAroundScene : MonoBehaviour {

	public Transform camera;
	public float speed;
	bool spotTouched = false;

	void Update() {
		if (spotTouched){
			float step = speed * Time.deltaTime;
			print (this.transform.position);
			camera.position = Vector3.MoveTowards(camera.position, transform.position, step);
			if (camera.position == transform.position) {
				spotTouched = false;

			}
		}
	}
	// Use this for initialization
	void OnMouseDown() {
		spotTouched = true;
	}
}

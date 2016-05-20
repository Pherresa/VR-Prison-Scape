using UnityEngine;
using System.Collections;

public class AddGravityOnCollision : MonoBehaviour {
	public Transform hammer;
	private Vector3 initPosition;
	private Quaternion initRotation;
	private Vector3 initVelocity;
	void OnCollisionEnter(Collision other){
		Debug.Log (other.gameObject.name);
		if (other.gameObject.tag == "pipe") {
			Debug.Log ("ENTEREDDDD");
			other.gameObject.GetComponent<Rigidbody> ().useGravity = true;
		}
	}
	// Use this for initialization
	void Start () {
		initPosition = hammer.position;
		initRotation = hammer.rotation;
		initVelocity = hammer.GetComponent<Rigidbody> ().velocity;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("r")) {
			hammer.position = initPosition;
			hammer.rotation = initRotation;
			hammer.GetComponent<Rigidbody> ().velocity = initVelocity;
		}
	}
}

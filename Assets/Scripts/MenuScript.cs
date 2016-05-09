using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public Button startText;
	public Button exitText;

	// Use this for initialization
	void Start () {
		
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
	}

	void Update() {
		
	}
	public void exitPress() {
		Debug.Log("EXIT ");
		Application.Quit ();
	}

	public void startGame() {
		Debug.Log ("STARTT");
		Application.LoadLevel ("PinchingSandbox");

	}

}


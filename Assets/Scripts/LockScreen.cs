using UnityEngine;
using System.Collections;

public class LockScreen : MonoBehaviour {

	public int addingValue = -1;
	public int clear = 0;
	int valueToBeAdded;
	public string code;
	string currentDisplayedCode = System.String.Empty;
	
	bool updating = false;
	
	void Start(){
	}
	
	void Update(){
		if (!updating){
			if (addingValue != -1){
				updating = true;
				currentDisplayedCode += addingValue.ToString();
				addingValue = -1;
				Debug.Log("Current code :");
				Debug.Log(currentDisplayedCode);
				
				if (currentDisplayedCode.Length == code.Length){
					if (currentDisplayedCode == code){
						Debug.Log("Correct code !!");
						//TODO Camera movement + Open door + victory screen (+ sound)
					} else {
						//TODO : beeping ?
						Debug.Log("Wrong code !! Resetting..");
						currentDisplayedCode = System.String.Empty;
					}
				}
				
				updating = false;
			} else if (clear == 1){
				updating = true;
				currentDisplayedCode = System.String.Empty;
				clear = 0;
				Debug.Log("Cleared");
				updating = false;
			}
		}
	}
}
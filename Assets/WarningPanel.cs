using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WarningPanel : MonoBehaviour {
	public static WarningPanel Instance;
	public Text messageTxt;

	void Awake(){
		Instance = this;
	}
	
	public void Init(string message){
		if (Instance != null) {
			gameObject.SetActive (false);
			messageTxt.text = message;
		}
	}
}

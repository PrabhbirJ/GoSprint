using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HomeMenu_UpdateParameter : MonoBehaviour {

	public Text[] StarTxt;
	public Text[] HeartTxt;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (StarTxt.Length > 0) {
			foreach (var star in StarTxt) {
				star.text = GlobalValue.SavedStar + "";
			}
		}

		if (HeartTxt.Length > 0) {
			foreach (var heart in HeartTxt) {
				heart.text = GlobalValue.SavedLives + "";
			}
		}
	}
}

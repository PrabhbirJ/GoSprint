using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu_GameOver : MonoBehaviour {

	public Text runTxt;
	public Text bestTxt;
	public Text animalsTxt;
	public Text starTxt;

	void OnEnable(){

		SoundManager.PlayMusic (FindObjectOfType<SoundManager>().soundGameover, 0.5f);
	}

	// Use this for initialization
	void Start () {
		runTxt.text = GameManager.Instance.Distance + "";
		bestTxt.text = GlobalValue.BestDistance + "";
		animalsTxt.text = GameManager.Instance.Animal + "";
		starTxt.text = GameManager.Instance.Star + "";

	}
}

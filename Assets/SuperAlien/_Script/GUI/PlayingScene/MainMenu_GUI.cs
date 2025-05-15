using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu_GUI : MonoBehaviour {
	public static MainMenu_GUI Instance;

	//boost items
	public Button Gorilla;
	public Text GorillaLeftTxt;
	public Button Buffalo;
	public Text BuffaloLeftTxt;
	public Button Rocket;
	public Text RocketLeftTxt;
	public Text RocketCoolDownTxt;

	public Text starTxt;
	public Text distanceTxt;
	public Text animalTxt;
	public Text liveTxt;
	public GameObject CoolDownItem;
	public Text coolDownText;

	[HideInInspector]
	public int cooldownValue;

	int startTime,currentTime;
	int coolDownValue;
	int coolDownRocketTime;
	int startTimeCoolDownRocket;
	bool isCoolDownRocket = false;

	// Use this for initialization
	void Start () {
		Instance = this;
		
	}
	
	// Update is called once per frame
	void Update () {
		starTxt.text = GameManager.Instance.Star + "";
		distanceTxt.text = (int)GameManager.Instance.Distance + "M";
		animalTxt.text = GameManager.Instance.Animal + "";
		liveTxt.text = GlobalValue.SavedLives + "";

		CoolDownItem.SetActive (cooldownValue > 0);
		coolDownText.text = cooldownValue + "";

		GorillaLeftTxt.text = GlobalValue.Gorilla + "";
		BuffaloLeftTxt.text = GlobalValue.Buffalo + "";
		RocketLeftTxt.text = GlobalValue.Rocket + "";

		Gorilla.interactable = GlobalValue.Gorilla > 0 && GlobalValue.CompleteTutorial == 1;
		Buffalo.interactable = GlobalValue.Buffalo > 0 && GlobalValue.CompleteTutorial == 1;
		Rocket.interactable = GlobalValue.Rocket > 0 && !isCoolDownRocket && !GameManager.Instance.Player.isUsingJetpack 
			&& !CharacterHandle.Instance.isUsingRider && GlobalValue.CompleteTutorial == 1;

		if (GameManager.Instance.Player.isUsingJetpack) {
			currentTime = (int) Time.realtimeSinceStartup - startTime;
			cooldownValue = coolDownValue - currentTime;

			if (currentTime >= coolDownValue) {
				coolDownRocketTime = GlobalValue.RocketCoolDownTime;
				GameManager.Instance.Player.isUsingJetpack = false;
				startTimeCoolDownRocket = (int) Time.realtimeSinceStartup;
				isCoolDownRocket = true;
				RocketCoolDownTxt.gameObject.SetActive (true);
			}
		}

		if (isCoolDownRocket) {
			var time = Time.realtimeSinceStartup - startTimeCoolDownRocket;
			var timeleft = coolDownRocketTime - (int) time;
			RocketCoolDownTxt.text = timeleft + "";
			if (timeleft <= 0 || CharacterHandle.Instance.isUsingRider) {
				isCoolDownRocket = false;
				RocketCoolDownTxt.gameObject.SetActive (false);
			}
		}
	}

	public void SwitchGorilla(){
		if (GameManager.Instance.State != GameManager.GameState.Playing)
			MenuManager.Instance.StartGame ();

		GlobalValue.Gorilla--;
		GlobalValue.TotalGorillaUsed++;
		CharacterHandle.Instance.SetAlienGorilla ();
	}

	public void SwitchBuffalo(){
		if (GameManager.Instance.State != GameManager.GameState.Playing)
			MenuManager.Instance.StartGame ();

		GlobalValue.Buffalo--;
		GlobalValue.TotalBuffaloUsed++;
		CharacterHandle.Instance.SetAlienBuffalo ();
	}

	public void UseJetPack(){
		if (GameManager.Instance.State != GameManager.GameState.Playing)
			MenuManager.Instance.StartGame ();

		startTime = (int) Time.realtimeSinceStartup;
		GlobalValue.Rocket--;
		GlobalValue.TotalRocketUsed++;
		GameManager.Instance.Player.isUsingJetpack = true;
		coolDownValue = GlobalValue.RocketTime;
	}
}

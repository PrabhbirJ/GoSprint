using UnityEngine;
using System.Collections;

public class CharacterHandle : MonoBehaviour {
	public static CharacterHandle Instance;
	public Player Alien;
	public Player AlienGorilla;
	public Player AlienBuffalo;

	public Transform ShowUpPoint;

	int startTime,currentTime;
	int coolDownValue;
	[HideInInspector]
	public bool isUsingRider = false;

	void Awake(){
		Instance = this;

		Alien.gameObject.SetActive (true);
		AlienGorilla.gameObject.SetActive (false);
		AlienBuffalo.gameObject.SetActive (false);

//		
	}



	// Use this for initialization
	void Start () {
		GameManager.Instance.Player = Alien;
	}

	void Update(){
		if (isUsingRider) {
			currentTime = (int) Time.realtimeSinceStartup - startTime;
			MainMenu_GUI.Instance.cooldownValue = coolDownValue - currentTime;

			if (currentTime >= coolDownValue) {
				SetAlien ();
			}
		}
	}

	public void SetAlien(){
		isUsingRider = false;

		Alien.transform.position = ShowUpPoint.position;

		Alien.gameObject.SetActive (true);
		AlienGorilla.gameObject.SetActive (false);
		AlienBuffalo.gameObject.SetActive (false);


		Alien.Boost (10, true);
		GameManager.Instance.Player = Alien;
	}

	public void SetAlienGorilla(){
		AlienGorilla.transform.position = ShowUpPoint.position;

		Alien.gameObject.SetActive (false);
		AlienGorilla.gameObject.SetActive (true);
		AlienBuffalo.gameObject.SetActive (false);

		AlienGorilla.Play ();
		AlienGorilla.Boost (10, true);

		GameManager.Instance.Player = AlienGorilla;


		coolDownValue = GlobalValue.GorillaTime;
		startTime = (int) Time.realtimeSinceStartup;
		isUsingRider = true;
	}

	public void SetAlienBuffalo(){
		AlienBuffalo.transform.position = ShowUpPoint.position;

		Alien.gameObject.SetActive (false);
		AlienGorilla.gameObject.SetActive (false);
		AlienBuffalo.gameObject.SetActive (true);

		AlienBuffalo.Play ();
		AlienBuffalo.Boost (10, true);
		GameManager.Instance.Player = AlienBuffalo;


		coolDownValue = GlobalValue.BuffaloTime;
		startTime = (int) Time.realtimeSinceStartup;
		isUsingRider = true;
	}
}

using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {
	public enum Type{Simple, Boost, Jumpdown, TapAndHold, Finish}
	public Type TutorialType;

	public GameObject Tut;

	bool isTutShowed = false;

	float playerSpeed;

	// Use this for initialization
	void Start () {
		if (Tut != null)
			Tut.SetActive (false);
	}

	void Update(){
		if (!isTutShowed)
			return;

		switch (TutorialType) {
		case Type.Simple:
			if (Input.anyKeyDown)
				KeepPlaying ();
			break;
		case Type.Boost:
			if(GameManager.Instance.Player.isBoostSpeed)
				KeepPlaying ();
			break;
		case Type.Jumpdown:
			if (GameManager.Instance.Player.input.y < 0)
				KeepPlaying ();
			break;
		case Type.TapAndHold:
			if (GameManager.Instance.Player.velocity.y < 0 && GameManager.Instance.Player.isHoldJump)
				KeepPlaying ();
			break;
		case Type.Finish:
			if (Input.anyKeyDown) {
				KeepPlaying ();
				GlobalValue.CompleteTutorial = 1;	//1 is true
				GameManager.Instance.startDistance = (int) GameManager.Instance.Player.transform.position.x;
			}
			break;
		default:

			break;
		}
	}

	private void KeepPlaying(){
		GameManager.Instance.Player.moveSpeed = playerSpeed;
		if (Tut != null)
			Tut.SetActive (false);
		isTutShowed = false;

		enabled = false;
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.GetComponent<Player> () == null || isTutShowed)
			return;
		
		//store the current speed of player
		playerSpeed = GameManager.Instance.Player.moveSpeed;
		//stop the player
		GameManager.Instance.Player.moveSpeed = 0;
		Tut.SetActive (true);
		isTutShowed = true;

	}
}

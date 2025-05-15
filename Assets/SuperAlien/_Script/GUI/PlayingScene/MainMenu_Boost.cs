using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu_Boost : MonoBehaviour {

	public Button Boost1;
	public int Boost1Distance = 35;
	public Button Boost2;
	public int Boost2Distance = 70;
	public Button Boost3;
	public int Boost3Distance = 100;

	public Text distance1;
	public Text amount1;
	public Text distance2;
	public Text amount2;
	public Text distance3;
	public Text amount3;

	// Use this for initialization
	void Start () {
		gameObject.SetActive (GlobalValue.CompleteTutorial == 1);

		Boost1.interactable = GlobalValue.Boost1 > 0;
		Boost2.interactable = GlobalValue.Boost2 > 0;
		Boost3.interactable = GlobalValue.Boost3 > 0;

		distance1.text = Boost1Distance + "M";
		amount1.text = GlobalValue.Boost1 + "";

		distance2.text = Boost2Distance + "M";
		amount2.text = GlobalValue.Boost2 + "";

		distance3.text = Boost3Distance + "M";
		amount3.text = GlobalValue.Boost3 + "";
	}
	
	public void SetBoost1(){
		GlobalValue.Boost1--;
		MenuManager.Instance.StartGame ();
		GameManager.Instance.Player.Boost (Boost1Distance, true);

	}

	public void SetBoost2(){
		GlobalValue.Boost2--;
		MenuManager.Instance.StartGame ();
		GameManager.Instance.Player.Boost (Boost2Distance, true);
	}

	public void SetBoost3(){
		GlobalValue.Boost3--;
		MenuManager.Instance.StartGame ();
		GameManager.Instance.Player.Boost (Boost3Distance, true);
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemLive : MonoBehaviour {

	public int price = 100;
	public int lives = 1;

	public Text priceTxt;
	public Text liveTxt;
	public AudioClip soundPurchase;


	// Use this for initialization
	void Start () {
		priceTxt.text = price + "";
		liveTxt.text =  "x" + lives.ToString ("00");
	}
	
	public void Buy(){
		if (GlobalValue.SavedStar >= price) {
			GlobalValue.SavedStar -= price;
			SoundManager.PlaySfx (soundPurchase);

			GlobalValue.SavedLives += lives;
		} else {
			MainMenu_StartMenu.Instance.OpenAskToBuyCoin ();
		}
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonChangeScene : MonoBehaviour {
	public GameObject Unlock;

	public int price = 500;
	public AudioClip soundPurchase;

	// Use this for initialization
	void Start () {
		GetComponent<Button> ().enabled = GlobalValue.isFarmUnlocked;
		Unlock.SetActive (!GlobalValue.isFarmUnlocked);
	}
	
	public void UnlockScene(){
		if (GlobalValue.SavedStar >= price) {
			GlobalValue.SavedStar -= price;
			GlobalValue.isFarmUnlocked = true;
			SoundManager.PlaySfx (soundPurchase);
			Unlock.SetActive (false);
			GetComponent<Button>().enabled = GlobalValue.isFarmUnlocked;
		} else
			MainMenu_StartMenu.Instance.OpenAskToBuyCoin ();
	}
}

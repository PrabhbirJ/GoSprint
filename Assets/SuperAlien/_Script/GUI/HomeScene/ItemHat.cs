using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemHat : MonoBehaviour {

	public bool isFree = false;
	public int ID;		//set the ID of the item
	public int price;		//set the price of the item
	public Image itemImage;		//the image of the item
	public Text stateTxt;
	public GameObject starIcon;
	public GameObject Equipped;
	bool isUnlock;	//check if it's unlocked or not
	public AudioClip soundUnlock;

	// Use this for initialization
	void Start () {
		CheckUnlock ();		//check
		itemImage.sprite = ClothHandle.Instance.GetHatImage (ID);		//if the ball is unlocked, set the image for it
	}

	private void CheckUnlock(){
		if (isFree)
			isUnlock = true;
		else
			isUnlock = ClothHandle.Instance.isHatUnlocked (ID);
	}

	void Update(){
		if (isUnlock)
			stateTxt.text = GlobalValue.ChoosenHat == ID ? "Unequip" : "Equip";
		else 
			stateTxt.text = price + "";

		stateTxt.gameObject.SetActive (GlobalValue.ChoosenHat != ID);
		Equipped.SetActive (GlobalValue.ChoosenHat == ID);
		starIcon.SetActive (!isUnlock);
	}

	//call by the button event itself
	public void Click(){
		if (!isUnlock)
			CheckCoinsToUnlock ();		//if this		 item is not unlocked then unlock it
		else {
			GlobalValue.ChoosenHat = ID;		//save the choosen ball, when you play the game again, it will take this ball
		}	
	}

	private void CheckCoinsToUnlock(){
		if (GlobalValue.SavedStar >= price) {
			GlobalValue.SavedStar -= price;
			ClothHandle.Instance.UnlockHat (ID);
			CheckUnlock ();
			SoundManager.PlaySfx (soundUnlock);
		} else {
			MainMenu_StartMenu.Instance.OpenAskToBuyCoin ();
		}
	}
}

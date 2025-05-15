using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shop_Items : MonoBehaviour {
	public AudioClip soundPurchased;

	public Text rocketLeftTxt;
	public Text rocketPriceTxt;
	public int rocketPrice = 0;

	public Text gorillaLeftTxt;
	public Text gorillaPriceTxt;
	public int gorillaPrice = 0;

	public Text buffaloLeftTxt;
	public Text buffaloPriceTxt;
	public int buffaloPrice = 0;

	public Text doubleStarPriceTxt;
	public int doubleStarPrice = 0;

	public Text boost1LeftTxt;
	public Text boost1PriceTxt;
	public int boost1Price = 0;

	public Text boost2LeftTxt;
	public Text boost2PriceTxt;
	public int boost2Price = 0;

	public Text boost3LeftTxt;
	public Text boost3PriceTxt;
	public int boost3Price = 0;

	[Header("UPGRADE")]

	public Text boostCurrentDistanceTxt;
	public Text boostDistancePriceTxt;
	public int boostDistancePrice = 0;
	public int boostDistanceAdd = 1;
	public int boostDistanceMax = 20;

	public Text rocketCurrentTimeTxt;
	public Text rocketTimePriceTxt;
	public int rocketTimePrice = 0;
	public int rocketTimeAdd = 1;
	public int rocketTimeMax = 20;

	public Text rocketCoolDownTimeTxt;
	public Text rocketCoolDownPriceTxt;
	public int rocketCoolDownPrice = 0;
	public int rocketCoolDownSubtract = 1;
	public int rocketCoolDownMin = 5;

	public Text gorillaTimeTxt;
	public Text gorillaTimePriceTxt;
	public int gorillaTimePrice = 0;
	public int gorillaTimeAdd = 1;
	public int gorillaTimeMax = 35;

	public Text buffaloTimeTxt;
	public Text buffaloTimePriceTxt;
	public int buffaloTimePrice = 0;
	public int buffaloTimeAdd = 1;
	public int buffaloTimeMax = 35;




	// Use this for initialization
	void Start () {

		rocketPriceTxt.text = rocketPrice + "";
		gorillaPriceTxt.text = gorillaPrice + "";
		buffaloPriceTxt.text = buffaloPrice + "";
		doubleStarPriceTxt.text = doubleStarPrice + "";
		boost1PriceTxt.text = boost1Price + "";
		boost2PriceTxt.text = boost2Price + "";
		boost3PriceTxt.text = boost3Price + "";

//		boostDistancePriceTxt.text = boostDistancePrice + "";
//		rocketTimePriceTxt.text = rocketTimePrice + "";
//		rocketCoolDownPriceTxt.text = rocketCoolDownPrice + "";
//		gorillaTimePriceTxt.text = gorillaTimePrice + "";
//		buffaloTimePriceTxt.text = buffaloTimePrice + "";
	}
	
	// Update is called once per frame
	void Update () {
		rocketLeftTxt.text = GlobalValue.Rocket + "";
		gorillaLeftTxt.text = GlobalValue.Gorilla + "";
		buffaloLeftTxt.text = GlobalValue.Buffalo + "";
		boost1LeftTxt.text = GlobalValue.Boost1 + "";
		boost2LeftTxt.text = GlobalValue.Boost2 + "";
		boost3LeftTxt.text = GlobalValue.Boost3 + "";

		boostCurrentDistanceTxt.text = GlobalValue.BoostDistance + "";
		rocketCurrentTimeTxt.text = GlobalValue.RocketTime + "";
		rocketCoolDownTimeTxt.text = GlobalValue.RocketCoolDownTime + "";
		gorillaTimeTxt.text = GlobalValue.GorillaTime + "";
		buffaloTimeTxt.text = GlobalValue.BuffaloTime + "";

		boostDistancePriceTxt.text = GlobalValue.BoostDistance < boostDistanceMax ? boostDistancePrice + "" : "MAX";
		rocketTimePriceTxt.text = GlobalValue.RocketTime < rocketTimeMax ? rocketTimePrice + "" : "MAX";
		rocketCoolDownPriceTxt.text = GlobalValue.RocketCoolDownTime > rocketCoolDownMin ? rocketCoolDownPrice + "" : "MIN";
		gorillaTimePriceTxt.text = GlobalValue.GorillaTime < gorillaTimeMax ? gorillaTimePrice + "" : "MAX";
		buffaloTimePriceTxt.text = GlobalValue.BuffaloTime < buffaloTimeMax ? buffaloTimePrice + "" : "MAX";
	}

	///ROCKET
	/// 
	/// 
	public void BuyRocket(){
		if (rocketPrice <= GlobalValue.SavedStar) {
			SoundManager.PlaySfx (soundPurchased);
			GlobalValue.SavedStar -= rocketPrice;

			GlobalValue.Rocket++;
		} else {
			
			MainMenu_StartMenu.Instance.OpenAskToBuyCoin ();
		}
	}

	///GORILLA
	/// 
	/// 
	public void BuyGorilla(){
		if (gorillaPrice <= GlobalValue.SavedStar) {
			SoundManager.PlaySfx (soundPurchased);
			GlobalValue.SavedStar -= gorillaPrice;

			GlobalValue.Gorilla++;
		} else {
			
			MainMenu_StartMenu.Instance.OpenAskToBuyCoin ();
		}
	}

	///BUFFALO
	/// 
	/// 
	public void BuyBuffalo(){
		if (buffaloPrice <= GlobalValue.SavedStar) {
			SoundManager.PlaySfx (soundPurchased);
			GlobalValue.SavedStar -= buffaloPrice;

			GlobalValue.Buffalo++;
		} else {
			
			MainMenu_StartMenu.Instance.OpenAskToBuyCoin ();
		}
	}

	///DOUBLE STAR
	/// 
	/// 
	public void BuyDoubleStar(){
		if (doubleStarPrice <= GlobalValue.SavedStar ) {
			if (GlobalValue.DoubleStar == 0) {
				SoundManager.PlaySfx (soundPurchased);
				GlobalValue.SavedStar -= doubleStarPrice;

				GlobalValue.DoubleStar = 1;
			} else
				Debug.Log ("Bought");
		} else {
			
			MainMenu_StartMenu.Instance.OpenAskToBuyCoin ();
		}
	}

	///BOOST 1
	/// 
	/// 
	public void BuyBoost1(){
		if (boost1Price <= GlobalValue.SavedStar) {
			SoundManager.PlaySfx (soundPurchased);
			GlobalValue.SavedStar -= boost1Price;

			GlobalValue.Boost1++;
		} else {
			
			MainMenu_StartMenu.Instance.OpenAskToBuyCoin ();
		}
	}

	///BOOST 2
	/// 
	/// 
	public void BuyBoost2(){
		if (boost2Price <= GlobalValue.SavedStar) {
			SoundManager.PlaySfx (soundPurchased);
			GlobalValue.SavedStar -= boost2Price;

			GlobalValue.Boost2++;
		} else {
			
			MainMenu_StartMenu.Instance.OpenAskToBuyCoin ();
		}
	}

	///BOOST 3
	/// 
	/// 
	public void BuyBoost3(){
		if (boost3Price <= GlobalValue.SavedStar) {
			SoundManager.PlaySfx (soundPurchased);
			GlobalValue.SavedStar -= boost3Price;

			GlobalValue.Boost3++;
		} else {
			
			MainMenu_StartMenu.Instance.OpenAskToBuyCoin ();
		}
	}

	//UPGRADE

	public void BuyBoostDistance(){
		if (boostDistancePrice <= GlobalValue.SavedStar) {
			if (GlobalValue.BoostDistance < boostDistanceMax) {
				SoundManager.PlaySfx (soundPurchased);
				GlobalValue.SavedStar -= boostDistancePrice;

				GlobalValue.BoostDistance += boostDistanceAdd;
			} else
				Debug.Log ("Limited");
		} else {
			
			MainMenu_StartMenu.Instance.OpenAskToBuyCoin ();
		}
	}

	public void BuyRocketTime(){
		if (rocketTimePrice <= GlobalValue.SavedStar) {
			if (GlobalValue.RocketTime < rocketTimeMax) {
				SoundManager.PlaySfx (soundPurchased);
				GlobalValue.SavedStar -= rocketTimePrice;

				GlobalValue.RocketTime += rocketTimeAdd;
			} else
				Debug.Log ("Limited");
		} else {
			
			MainMenu_StartMenu.Instance.OpenAskToBuyCoin ();
		}
	}

	public void BuyRocketCoolDown(){
		if (rocketCoolDownPrice <= GlobalValue.SavedStar) {
			if (GlobalValue.RocketCoolDownTime > rocketCoolDownMin) {
				SoundManager.PlaySfx (soundPurchased);
				GlobalValue.SavedStar -= rocketCoolDownPrice;

				GlobalValue.RocketCoolDownTime -= rocketCoolDownSubtract;
			} else
				Debug.Log ("Limited");
		} else {
			
			MainMenu_StartMenu.Instance.OpenAskToBuyCoin ();
		}
	}

	public void BuyGorillaTime(){
		if (gorillaTimePrice <= GlobalValue.SavedStar) {
			if (GlobalValue.GorillaTime < gorillaTimeMax) {
				SoundManager.PlaySfx (soundPurchased);
				GlobalValue.SavedStar -= gorillaTimePrice;

				GlobalValue.GorillaTime += gorillaTimeAdd;
			} else
				Debug.Log ("Limited");
		} else {
			
			MainMenu_StartMenu.Instance.OpenAskToBuyCoin ();
		}
	}

	public void BuyBuffaloTime(){
		if (buffaloTimePrice <= GlobalValue.SavedStar) {
			if (GlobalValue.BuffaloTime < buffaloTimeMax) {
				SoundManager.PlaySfx (soundPurchased);
				GlobalValue.SavedStar -= buffaloTimePrice;

				GlobalValue.BuffaloTime += buffaloTimeAdd;
			} else
				Debug.Log ("Limited");
		} else {
			
			MainMenu_StartMenu.Instance.OpenAskToBuyCoin ();
		}
	}

}

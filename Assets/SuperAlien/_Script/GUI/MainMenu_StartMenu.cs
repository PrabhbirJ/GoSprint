using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu_StartMenu : MonoBehaviour {
	public static MainMenu_StartMenu Instance;

	public GameObject Shop;
	public GameObject AnimalList;
	public GameObject AskQuitGame;
	public GameObject Loading;
	public GameObject Information;
	public GameObject Profile;
	public GameObject AskToBuyCoin;


	public string facebookLink;
	public string twitterLink;
	public string moreGameLink;




	public Animator animChangeScene;
	bool isJungle = true;

	[Header("Settings")]
	public Animator animSettings;
	bool isSettingsShowed = false;

	[Header("Settings Buttons")]
	public GameObject SoundOff;

	public GameObject MusicOff;

	SoundManager soundManager;

	void Awake(){
		Instance = this;
	}

	// Use this for initialization
	void Start () {
		
		MusicOff.SetActive (!GlobalValue.isMusic);

		SoundOff.SetActive (!GlobalValue.isSound);

		soundManager = FindObjectOfType<SoundManager> ();
		AdmobVNTIS._showBanner ();
		Shop.SetActive (false);
		AnimalList.SetActive (false);
		AskQuitGame.SetActive (false);
		Loading.SetActive (false);
		Information.SetActive (false);
		Profile.SetActive (false);
		AskToBuyCoin.SetActive (false);
		

		if (GlobalValue.openShop) {
			OpenShop ();
			GlobalValue.openShop = false;
		}
	}

	public void PlayGame(){
		AdmobVNTIS._hideBanner ();
		string scene = isJungle ? "Playing Jungle" : "Playing Farm";
		SceneManager.LoadSceneAsync (scene);
		Loading.SetActive (true);
		AdmobVNTIS_Interstitial x = AdmobVNTIS_Interstitial._get ();

	}
	
	public void TurnMusic () {
		if (GlobalValue.isMusic) {
			GlobalValue.isMusic = false;
			SoundManager.MusicVolume = 0;
		} else {
			GlobalValue.isMusic = true;
			SoundManager.MusicVolume = 1;
		}

		MusicOff.SetActive (!GlobalValue.isMusic);
	}

	public void TurnSound(){
		if (GlobalValue.isSound) {
			GlobalValue.isSound = false;
			SoundManager.SoundVolume = 0;
		} else {
			GlobalValue.isSound = true;
			SoundManager.SoundVolume = 1;
		}

		SoundOff.SetActive (!GlobalValue.isSound);
	}

	public void OpenTwitter(){
		Application.OpenURL (twitterLink);

		SoundManager.PlaySfx (soundManager.soundClick);
	}

	public void OpenFacebook(){
		Application.OpenURL (facebookLink);

		SoundManager.PlaySfx (soundManager.soundClick);
	}

	public void OpenShop(){
		Shop.SetActive (true);
	}

	public void OpenAnimalList(){
		AnimalList.SetActive (true);
	}

	public void AskExitGame(){
		AskQuitGame.SetActive (true);
	}

	public void QuitGame(){
		Application.Quit ();
	}

	public void OpenShopCloth(){
		Shop.SetActive (true);
		Shop.GetComponent<HomeMenu_Shop> ().OpenShopCloth ();
	}

	public void ChangeScene(){
		if (isJungle) {
			animChangeScene.SetTrigger ("Farm");
			isJungle = false;
		} else {
			animChangeScene.SetTrigger ("Jungle");
			isJungle = true;
		}
	}

	public void Settings(){
		isSettingsShowed = !isSettingsShowed;

		animSettings.SetBool ("Show", isSettingsShowed);
	}

	public void OpenInformation(){
		Information.SetActive (true);
	}

	public void OpenProfile(){
		Profile.SetActive (true);
	}

	public void OpenAskToBuyCoin(){
		SoundManager.PlaySfx (soundManager.soundNotEnough);
		AskToBuyCoin.SetActive (true);
	}
}

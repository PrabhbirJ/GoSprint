using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
	public static MenuManager Instance;

	public GameObject Startmenu;
	public GameObject GUI;
	public GameObject Gameover;
//	public GameObject GameFinish;
	public GameObject GamePause;
	public GameObject LoadingScreen;
	public GameObject SaveMe;

	void Awake(){
		Instance = this;
		Startmenu.SetActive (true);
		GUI.SetActive (true);
		Gameover.SetActive (false);
//		GameFinish.SetActive (false);
		GamePause.SetActive (false);
		LoadingScreen.SetActive (true);
		SaveMe.SetActive (false);
	}

//	public void NextLevel(){
//		SoundManager.PlaySfx (SoundManager.Instance.soundClick);
//		LoadingSreen.Show ();
//		SceneManager.LoadSceneAsync (LevelManager.Instance.nextLevelName);
//	}

	public void RestartGame(){
		Time.timeScale = 1;
		SoundManager.PlaySfx (SoundManager.Instance.soundClick);
		LoadingSreen.Show ();
		SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().buildIndex);

	}

	public void HomeScene(){
		SoundManager.PlaySfx (SoundManager.Instance.soundClick);
		Time.timeScale = 1;
		LoadingSreen.Show ();
		SceneManager.LoadSceneAsync ("Home Scene");

	}

	public void GameOver(bool forceOver){
		GUI.SetActive (false);

		StartCoroutine (ShowMenuDelayCo (Gameover, forceOver ? 0 : 3));
		AdmobVNTIS_Interstitial._showInterstitialImmediately ();
	}

	public void Pause(){
		SoundManager.PlaySfx (SoundManager.Instance.soundClick);
		if (Time.timeScale == 0) {
			GamePause.SetActive (false);
			GUI.SetActive (true);
			Time.timeScale = 1;
			GameManager.Instance.State = GameManager.GameState.Playing;
		} else {
			GamePause.SetActive (true);
			GUI.SetActive (false);
			Time.timeScale = 0;
			GameManager.Instance.State = GameManager.GameState.Pause;
		}
	}

	public void StartGame(){
		Startmenu.SetActive (false);

		GameManager.Instance.StartGame ();
	}

	public void OpenShop(){
		GlobalValue.openShop = true;
		HomeScene ();
	}

	public void OpenSaveMe(){
		SaveMe.SetActive (true);
	}

	IEnumerator ShowMenuDelayCo(GameObject Menu, float time){
		yield return new WaitForSeconds (time);

		Menu.SetActive (true);
		SaveMe.SetActive (false);
	}
}

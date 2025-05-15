using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ResetData : MonoBehaviour {
	SoundManager soundManager;

	void Start(){
		soundManager = FindObjectOfType<SoundManager> ();
	}

	public void Reset(){
		PlayerPrefs.DeleteAll ();
		LoadingSreen.Show ();
		SceneManager.LoadSceneAsync (SceneManager.GetActiveScene ().buildIndex);
		MainMenu_StartMenu.Instance.Loading.SetActive (true);
		SoundManager.PlaySfx (soundManager.soundClick);
	}
}

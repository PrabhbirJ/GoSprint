using UnityEngine;
using System.Collections;
/// <summary>
/// if the player reach to the next target distance, this will active the changing to Player as well as gameplay such as: speed, platforms,music,...
/// </summary>

public class LevelManager : MonoBehaviour {
	public Parameters[] Parameter;
	int currentLevel = 0;

	// Use this for initialization
	void Start () {
		StartCoroutine (UpdateCo ());
	}
	
	// Update is called once per frame
	void Update () {
		var distance = GameManager.Instance.Distance;
		for (int i = 0; i < Parameter.Length; i++) {
			if (Parameter [i].activateDistance < distance && currentLevel < i) {
				currentLevel = i;
				SoundManager.PlayMusic (Parameter [currentLevel].gameMusic);
				break;
			}
		}

		GameManager.Instance.Player.speedMul = Parameter [currentLevel].PlayerSpeedMul;	//alway update in case the user change the player
	}

	IEnumerator UpdateCo(){
		yield return new WaitForSeconds (0);	//wait for next frame

		SoundManager.PlayMusic (Parameter [0].gameMusic);
		GameManager.Instance.Player.speedMul = Parameter [0].PlayerSpeedMul;
	}

	[System.Serializable]
	public class Parameters{
		public int activateDistance = 0;
		public float PlayerSpeedMul = 1f;
		public AudioClip gameMusic;
	}
}

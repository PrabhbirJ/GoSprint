using UnityEngine;
using System.Collections;

public class RocketManager : MonoBehaviour {

	public GameObject Rocket;

	public GameObject[] Warning;
	public Transform[] SpawnRocket;

	public float warningDelay = 2f;

	public float minAttack = 20;
	public float maxAttack = 40;

	public AudioClip soundWarning;
	public AudioClip soundFire;

	int rand;

	// Use this for initialization
	void Start () {
		DisableWarning ();

		StartCoroutine (AttackCo ());
	}

	private void DisableWarning(){
		foreach (var warning in Warning)
			warning.SetActive (false);
	}

	IEnumerator AttackCo(){
		var delay = Random.Range (minAttack, maxAttack);
		Debug.Log(delay);
		yield return new WaitForSeconds (delay);

		if (GameManager.Instance.State == GameManager.GameState.Playing && GlobalValue.CompleteTutorial == 1)
			StartCoroutine (WarningCo ());
		else
			StartCoroutine (AttackCo ());
	}

	IEnumerator WarningCo(){
		SoundManager.PlaySfx (soundWarning);
		rand = Random.Range (0, 3);
		int num = Random.Range(1, 3);
		int lastRand = rand;
		DisableWarning ();
		Warning [rand].SetActive (true);

		yield return new WaitForSeconds (warningDelay);
		DisableWarning ();

		SoundManager.PlaySfx (soundFire);
		while (num != 0){
			Instantiate(Rocket, SpawnRocket[rand].position, Quaternion.identity);
			rand = Random.Range(0, 3);
			if (lastRand == rand)
			{
				rand += 1;
			}
			num-=1;
		}

		StartCoroutine (AttackCo ());
	}
}

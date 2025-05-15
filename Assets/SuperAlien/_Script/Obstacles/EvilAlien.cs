using UnityEngine;
using System.Collections;

public class EvilAlien : MonoBehaviour {

	public float smooth = 100;
	public float speed = 10;

	public float followDistance = 7;
	public float closeDistance = 3;

	public float timeShowUpMin = 10;
	public float timeShowUpMax = 20;

	public GameObject Warning;
	public float delayWarning = 0.5f;

	[Range(2,10)]
	public float timeAttackMin = 2;
	[Range(5,20)]
	public float timeAttackMax = 6;

	public int maxAttackHit = 3;

	[Header("Sound")]
	public AudioClip soundShowup;
	public AudioClip soundAttack;
	public AudioClip[] soundLaugh;
	[Range(0,1)]
	public float laughVolume = 0.5f;

	int currentHit;
	int currentAllowHit;

	bool getClose = false;
	bool isReadyAttack = false;
	float offset = 0;

	Animator anim;

	// Use this for initialization
	void Start () {
		GameManager.Instance.EvilAlien = this;
		anim = GetComponent<Animator> ();
		Warning.SetActive (false);

		currentHit = 0;
		currentAllowHit = Mathf.Clamp (currentAllowHit, 1, maxAttackHit);
	}
	
	// Update is called once per frame
	void Update () {
//		if (GameManager.Instance.State != GameManager.GameState.Playing) {
//			Stop ();
//			return;
//		}
		if (GameManager.Instance.Player.isBoostSpeed) {
			offset = 0;
			return;
		}
		
		var targetX = GameManager.Instance.Player.transform.position.x - followDistance;
		var followPos = new Vector2 (targetX, transform.position.y);


//		transform.position = Vector2.Lerp (transform.position, followPos, (1/smooth));
		if (getClose) 
			offset += speed * Time.deltaTime;
		else
			offset -= speed * Time.deltaTime;
		

		offset = Mathf.Clamp (offset, 0, followDistance - closeDistance);

		isReadyAttack = offset == followDistance - closeDistance;


		followPos.x += offset;
		transform.position = followPos;
	}

	//called by Gamemanager
	public void Play(){
		StartCoroutine (GetCloseCo ());
	}


	public void Stop(){
		StopAllCoroutines ();
		getClose = true;

		if(soundLaugh.Length>0)
			SoundManager.PlaySfx (soundLaugh [Random.Range (0, soundLaugh.Length)],laughVolume);
	}

	IEnumerator GetCloseCo(){
		getClose = false;
		var delay = Random.Range (timeShowUpMin, timeShowUpMax);
		yield return new WaitForSeconds (delay);

		if (GlobalValue.CompleteTutorial == 1) {
			getClose = true;
			SoundManager.PlaySfx (soundShowup);

			StartCoroutine (AttackCo ());
		} else
			StartCoroutine (GetCloseCo ());

	}

	IEnumerator AttackCo(){
		var delay = Random.Range (timeAttackMin, timeAttackMax);
		yield return new WaitForSeconds (delay);
		Warning.SetActive (true);
		yield return new WaitForSeconds (delayWarning);
		Warning.SetActive (false);

		if (isReadyAttack)
			Attack ();
		else
			StartCoroutine (AttackCo ());
	}

	IEnumerator BackupCo(){
		
		var delay = Random.Range (2, 3);
		yield return new WaitForSeconds (delay);

		StartCoroutine (GetCloseCo ());
	}

	private void Attack(){
		SoundManager.PlaySfx (soundAttack);

		anim.SetTrigger ("Attack");
		currentHit++;
		if (currentHit < currentAllowHit)
			StartCoroutine (AttackCo ());
		else {
			currentHit = 0;
			currentAllowHit++;
			currentAllowHit = Mathf.Clamp (currentAllowHit, 1, maxAttackHit);
			StartCoroutine (BackupCo ());
		}
	}
}

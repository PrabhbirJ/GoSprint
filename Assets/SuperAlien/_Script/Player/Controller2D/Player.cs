using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour {
//	public bool GodMode;
	public bool isRider = false;		//if this is the controller for Gorilla or Buffalo

	[Header("Moving")]		
	public float moveSpeed = 3;			//moving speed of player
	public float speedMul{ get; set; }		//the final speed = speed*speedMul
	float accelerationTimeAirborne = .2f;
	float accelerationTimeGrounded = .1f;

	[Header("Jump")]
	public float maxJumpHeight = 3;		//highest jump player can reach
	public float minJumpHeight = 1;
	public float timeToJumpApex = .4f;
	public int numberOfJumpMax = 1;
	[HideInInspector]
	public bool isHoldJump = false;
	int numberOfJumpLeft;
	public GameObject JumpEffect;		

	[Header("Parasol")]
	public float fallDownSpeed = 0.9f;		//the falling speed when using the parasol

	[Header("BoostSpeed")]
	public float boostSpeed = 10f;		//the speed effect when using boost feature

	public bool isBoostSpeed { get; set; }
	float targetBoostSpeed;

	[Header("Effects")]
	public GameObject[] StarEffect;
	public ParticleSystem SmokeEffect;
	public ParticleSystem BoostEffect;

	[Header("Cloth")]
	public SpriteRenderer Glass;
	public SpriteRenderer Hat;

	[Header("Jetpack")]
	public GameObject Jetpack;
	public float jetpackForce = 10;		//jetpack force
	public ParticleSystem JetPackEffect;
	public bool isUsingJetpack{ get; set; }


	[Header("Sound")]
	public AudioClip jumpSound;
	[Range(0,1)]
	public float jumpSoundVolume = 0.5f;
	public AudioClip landSound;
	[Range(0,1)]
	public float landSoundVolume = 0.5f;
	public AudioClip boostSound;
	[Range(0,1)]
	public float boostSoundVolume = 0.5f;
	public AudioClip hurtSound;
	[Range(0,1)]
	public float hurtSoundVolume = 0.5f;
	public AudioClip deadSound;
	[Range(0,1)]
	public float deadSoundVolume = 0.5f;
	public AudioClip jumpDownSound;
	[Range(0,1)]
	public float jumpDownSoundVolume = 0.5f;
	[Header("Sound Effect")]
	public AudioClip soundSpring;
	public AudioClip soundFallDead;
	public AudioClip jetpackSound;
	public AudioClip collectSound;

	bool isPlayedLandSound;

	float gravity;
	float maxJumpVelocity;
	float minJumpVelocity;
	[HideInInspector]
	public Vector3 velocity;
	float velocityXSmoothing;

	[HideInInspector]
	public Vector2 input;

	[HideInInspector]
	public Controller2D controller;
	Animator anim;

	private AudioSource AudioJetpack;


	public bool isPlaying { get; set;}
	public bool isFinish { get; set;}

	void Awake(){
		controller = GetComponent<Controller2D> ();		//get Controller2D and Animator component
		anim = GetComponent<Animator> ();

		SmokeEffect.gameObject.SetActive (true);		//turn on the effects
		BoostEffect.gameObject.SetActive (true);
		SetEmissionRate (SmokeEffect, 0);		//turn off the effect by setting the emission rate to 0
		SetEmissionRate (BoostEffect, 0);
	}

	void Start() {
		
		//calculating the value of jump
		gravity = -(2 * maxJumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		minJumpVelocity = Mathf.Sqrt (2 * Mathf.Abs (gravity) * minJumpHeight);

		numberOfJumpLeft = numberOfJumpMax;

		input = new Vector2 (1, 0);		//make the player moving to right

		//Set Cloth
		if (ClothHandle.Instance != null) {		//the ClothHandle only available when you begin from the Main Menu scene
			Glass.sprite = ClothHandle.Instance.GetGlassImage (GlobalValue.ChoosenGlass);
			Hat.sprite = ClothHandle.Instance.GetHatImage (GlobalValue.ChoosenHat);
		}

		//set up the Audio source for jetpack sound
		AudioJetpack = gameObject.AddComponent<AudioSource> ();
		AudioJetpack.loop = true;
		AudioJetpack.playOnAwake = false;
		AudioJetpack.clip = jetpackSound;
		AudioJetpack.volume = 0;

		AudioJetpack.Play ();
	}

	void Update() {
//		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		velocity.y += gravity * Time.deltaTime;
		if (PlatformManager.Instance.currentTutorial == 5)
		{
			MainMenu_EnergyBar.Instance.starCount = MainMenu_EnergyBar.Instance.starFull;
		}
		//set smoke and boost effect
		SetEmissionRate (SmokeEffect, controller.collisions.below && isPlaying && moveSpeed > 0 ? 20 : 0);
		SetEmissionRate (BoostEffect, isBoostSpeed && isPlaying ? 200 : 0);

		//Set jectpack effect if there has a jetpack object
		if (Jetpack != null)
			Jetpack.SetActive (isUsingJetpack && isPlaying);		//only set the jetpack active when using the jetpack and is playing
		if (isUsingJetpack && isPlaying) {
			if (velocity.y > 0)
				SetEmissionRate (JetPackEffect, 200);		//set the rate of jetpack to 200 and 50 when player go up and down as well as the sound
			else
				SetEmissionRate (JetPackEffect, 50);

			AudioJetpack.volume = velocity.y > 0 ? 0.8f : 0.2f;
		} else
			AudioJetpack.volume = 0;

		if (!isPlaying)
			return;		//if the game are not in playing mode, stop right here
		
		HandleInput ();		//handle the PC input

		controller.HandlePhysic = !isBoostSpeed;	//if the player are in boost effect, turn off all colliders with the platform

		if (isBoostSpeed) {
			float targetVelocityX = input.x * boostSpeed;
			velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
			velocity.y = 0;
			if (transform.position.x >= targetBoostSpeed)
				isBoostSpeed = false;
		} else {
			float targetVelocityX = input.x * moveSpeed * speedMul;
			velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
		}

		if (isHoldJump && velocity.y < 0 && !controller.collisions.below && !isUsingJetpack)
			velocity.y = -fallDownSpeed;

		//check to play land sound
		if (controller.collisions.below && !isPlayedLandSound) {
			input.y = 0;
			isPlayedLandSound = true;
			SoundManager.PlaySfx (landSound, landSoundVolume);
		} else if (!controller.collisions.below && isPlayedLandSound)
			isPlayedLandSound = false;



		UpdateAniamtion (); 	//update the state to animator
	}

	void LateUpdate(){
		controller.Move (velocity * Time.deltaTime, input);

		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}
	}

	public void SetEmissionRate(ParticleSystem particleSystem, float emissionRate)
	{
		var emission = particleSystem.emission;
		var rate = emission.rate;
		rate.constantMax = emissionRate;
		emission.rate = rate;
	}

	//send by GameManager
	public void Play(){
		isPlaying = true;
		if (!isRider)
			anim.SetBool ("Run", true);

		Boost (10, true);
	}



	/// <summary>
	/// Controller	/// </summary>
	/// <param name="pos">Position.</param>

	private void HandleInput(){
//		if (Input.GetKey (KeyCode.A))
//			MoveLeft ();
		if (Input.GetKey (KeyCode.D))
			Boost (GlobalValue.BoostDistance,false);
//		else if((Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.D)))
//			StopMove ();
//
		if (Input.GetKeyDown (KeyCode.S))
			JumpDown ();
//		if (Input.GetKeyUp (KeyCode.S))
//			JumpDownOff ();
//			
//
		if (Input.GetKeyDown (KeyCode.Space)) {
			Jump ();
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			JumpOff ();
		}

		if (isUsingJetpack && Input.GetKey (KeyCode.Space)) {
			JetPack ();
		}
	}

	//Boost effect, distance: how far the player will boost, ignoreEnergyBar: normally, the player only can boost when he collect enough the stars,
	//but if you set the ignoreEnergyBar = true then it will boost without the stars
	public void Boost(float distance, bool ignoreEnergyBar){
		ResetAnimation ();

		if (ignoreEnergyBar) {
			SoundManager.PlaySfx (boostSound, boostSoundVolume);
			isBoostSpeed = true;
			targetBoostSpeed = transform.position.x + distance;
		
		} else if (MainMenu_EnergyBar.Instance.isBoostReady) {
			SoundManager.PlaySfx (boostSound, boostSoundVolume);
			isBoostSpeed = true;
			targetBoostSpeed = transform.position.x + distance;

			MainMenu_EnergyBar.Instance.starCount = 0;
		}
		
	}

	//jump down effect when the player are on the top platform or in the air
	public void JumpDown(){
		ResetAnimation ();

		//if the player are on the ground, then only let the player fall down
		if (controller.collisions.below) {
			velocity.y = -10;
			input.y = -1;
			SoundManager.PlaySfx (jumpDownSound, jumpDownSoundVolume);
			anim.SetBool ("JumpDown", true);

		}
		else {
			velocity.y = -10;
			SoundManager.PlaySfx (jumpDownSound, jumpDownSoundVolume);
			anim.SetBool ("JumpDown", true);
		}
	}


//	public void JumpDownOff(){
//		input.y = 0;
//	}


	public void Jump(){
		if (!isPlaying || (!isRider && isUsingJetpack))
			return;

		ResetAnimation ();

		isHoldJump = true;
		
		if (controller.collisions.below) {
			velocity.y = maxJumpVelocity;

			if (JumpEffect != null)
				Instantiate (JumpEffect, transform.position, transform.rotation);
			SoundManager.PlaySfx (jumpSound, jumpSoundVolume);
			numberOfJumpLeft = numberOfJumpMax;
		} else {
			numberOfJumpLeft--;
			if (numberOfJumpLeft > 0) {
				velocity.y = minJumpVelocity;

				if (JumpEffect != null)
					Instantiate (JumpEffect, transform.position, transform.rotation);
				SoundManager.PlaySfx (jumpSound, jumpSoundVolume);
			}
		}
	}


	public void JumpOff(){
		isHoldJump = false;

		if (velocity.y > minJumpVelocity) {
			velocity.y = minJumpVelocity;
		}
	}

	public void JetPack(){
		AddForce (new Vector2 (0, jetpackForce * Time.deltaTime));
	}


	/// <summary>
	///.</param>
	public void SetForce(Vector2 force){
		velocity = (Vector3)force;
//		controller.SetForce(force);
	}

	public void AddForce(Vector2 force){
		velocity += (Vector3) force;
	}
		

	void UpdateAniamtion(){
		//set animation state
//		anim.SetFloat ("speed", Mathf.Abs(input.x));
//		anim.SetFloat ("height_speed", velocity.y);
		anim.SetBool ("Ground", controller.collisions.below);

		anim.SetBool ("BoostSpeed", isBoostSpeed);
		if (controller.collisions.below)
			anim.SetBool ("JumpDown", false);
		anim.SetBool ("Parasol", isHoldJump && velocity.y < 0 && !controller.collisions.below);
		if (!isRider)
			anim.SetBool ("isPlaying", isPlaying);
	}

	void ResetAnimation(){
//		anim.SetFloat ("height_speed", 0);
		anim.SetBool ("Parasol", false);
		anim.SetBool ("JumpDown", false);
		if (!isRider)
			anim.SetBool ("isPlaying", false);
//		anim.SetTrigger ("reset");
	}

	public void GameFinish(){
		isPlaying = false;
		anim.SetTrigger ("finish");
	}


	//called by GameManger
	public void Dead(){
		if (isPlaying) {
			isPlaying = false;


			SetForce (new Vector2 (0, 7f));
//			controller.HandlePhysic = false;
		}
	}

	public void Reborn(){
		isPlaying = true;
//		anim.SetTrigger ("Reset");

		CharacterHandle.Instance.SetAlien ();
	}

	///////
	/// Dead
	/// 

	public void DeadByEnemy(){
		SoundManager.PlaySfx (hurtSound, hurtSoundVolume);
		ResetAnimation ();
		anim.SetTrigger ("Dead");
	}

	public void HitByRocket(){
		if (!isBoostSpeed && !isRider) {
			GameManager.Instance.GameOver ();
			ResetAnimation ();
			anim.SetTrigger ("Dead-Rocket");
		}
	}

	public void DeadByPunch(){
		if (isRider)
			return;

		SoundManager.PlaySfx (hurtSound, hurtSoundVolume);
		ResetAnimation ();
		anim.SetTrigger ("Dead-Punch");
	}

////////////////
	/// 
	/// 
	/// TRigger and Collider
	/// 
	/// 

	void OnTriggerEnter2D(Collider2D other){
		if (!isPlaying)
			return;
		
		if (other.CompareTag ("Star")) {	//collect the star trigger
			SoundManager.PlaySfx (collectSound);
			GameManager.Instance.Star++;
			GlobalValue.TotalStarEarned++;
			Destroy (other.gameObject);
			if (StarEffect.Length > 0) {		
				foreach (var Effect in StarEffect)
					Instantiate (Effect, other.transform.position, Quaternion.identity);
			}
		} else if (other.CompareTag ("Punch") && !isRider) {
			GameManager.Instance.GameOver ();
			DeadByPunch ();
		} else if (other.CompareTag ("Finish")) {
			if (!isRider) {
				SoundManager.PlaySfx (soundFallDead);
				GameManager.Instance.GameOver ();
			} else
				CharacterHandle.Instance.SetAlien ();		//if the Raider fall down then set the Alien back
			
		} else if (other.CompareTag ("Animal")) {
			GameManager.Instance.Animal++;
			other.gameObject.SendMessage ("Broken", SendMessageOptions.DontRequireReceiver);
		} else if (string.Compare (LayerMask.LayerToName (other.gameObject.layer), "Spring") == 0) {
			velocity.y = 20;
			other.GetComponent<Animator> ().SetTrigger ("Push");
			SoundManager.PlaySfx (soundSpring);
		}	
	}	

	void OnTriggerStay2D(Collider2D other){
		if (other.CompareTag ("Enemy") && isPlaying) {
			if (isRider || isBoostSpeed)
				other.gameObject.SendMessage ("Broken", SendMessageOptions.DontRequireReceiver);
			else if (controller.collisions.left || controller.collisions.right) {
				GameManager.Instance.GameOver ();
				DeadByEnemy ();
			}
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.CompareTag ("Through")) {
			input.y = 0;
		}
	}

}

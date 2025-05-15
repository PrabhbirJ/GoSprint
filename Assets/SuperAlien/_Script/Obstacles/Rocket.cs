using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {
	public float speed = 5f;
	public GameObject ExplosionFx;
	public AudioClip explosionSound;
	
	// Update is called once per frame
	
	void Update () {
		transform.Translate (-speed * Time.deltaTime, 0, 0);
	}

	void OnBecameInvisible(){
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D other){
		var Player = other.GetComponent<Player> ();
		if (Player == null)
			return;


		Player.HitByRocket ();

		if (ExplosionFx != null)
			Instantiate (ExplosionFx, other.transform.position, Quaternion.identity);

		SoundManager.PlaySfx (explosionSound);
		Destroy (gameObject);
	}
}

using UnityEngine;
using System.Collections;

public class AnimalBonus : MonoBehaviour {
	public GameObject BrokenFx;

	void OnTriggerEnter2D(Collider2D other){
		if (other.GetComponent<Player> () != null) {
			if (BrokenFx != null) {
				GameObject broken =  Instantiate (BrokenFx, transform.position, transform.rotation) as GameObject;
				broken.GetComponent<Animator> ().SetTrigger ("Break");
			}

			GlobalValue.Gorilla++;
			Destroy (gameObject);
		}
	}
}

using UnityEngine;
using System.Collections;

public class Hippo : MonoBehaviour {

	public Animator anim;

	void OnTriggerEnter2D(Collider2D other){
		if (other.GetComponent<Player> () != null) {
			anim.SetTrigger ("Raise");
			enabled = false;
		}
	}
}

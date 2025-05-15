using UnityEngine;
using System.Collections;

public class StaticObject : MonoBehaviour {
	public GameObject BrokenEffect;
	public AudioClip soundBroken;


	public void Broken(){
		if (BrokenEffect != null) {
			SoundManager.PlaySfx (soundBroken);
			Instantiate (BrokenEffect, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
}

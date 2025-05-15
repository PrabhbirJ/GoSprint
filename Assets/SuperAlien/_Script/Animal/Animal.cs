using UnityEngine;
using System.Collections;

public class Animal : MonoBehaviour {
	public AnimalName animalName;
	public Animator animalAnim;
	public AudioClip rescueSound;
	public AudioClip soundBreakCage;

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	public void Broken(){
		enabled = false;

		anim.SetTrigger ("Break");
		animalAnim.SetTrigger ("Happy");
		SoundManager.PlaySfx (rescueSound,0.35f);
		SoundManager.PlaySfx (soundBreakCage);

		GlobalValue.SetSaved (animalName.animal.ToString ());
		GlobalValue.TotalAnimal++;
	}
}

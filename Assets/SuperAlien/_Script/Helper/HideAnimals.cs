using UnityEngine;
using System.Collections;

public class HideAnimals : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Animal")) {
			Destroy (other.gameObject);
		}
	}
}

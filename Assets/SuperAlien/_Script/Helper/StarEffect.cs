using UnityEngine;
using System.Collections;

public class StarEffect : MonoBehaviour {

	public float speed = 10;

	// Use this for initialization
	void Start () {
		transform.SetParent (Camera.main.transform);
	}
	
	// Update is called once per frame
	void Update () {
//		var destination = Camera.main.ScreenToWorldPoint (MainMenu_EnergyBar.Instance.StarHeader.position);
		var destination = MainMenu_EnergyBar.Instance.StarHeader.position;
		transform.position = Vector3.MoveTowards (transform.position, destination, speed * Time.deltaTime);
		if (Vector3.Distance (transform.position, destination) < 0.2f) {
			MainMenu_EnergyBar.Instance.CollectStar ();
			Destroy (gameObject);
		}
	}
}

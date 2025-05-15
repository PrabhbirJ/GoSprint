using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowFPS : MonoBehaviour {
	public Text txtFPS;
	public float DeltaTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		DeltaTime = Time.deltaTime;
		txtFPS.text = 1/DeltaTime+"";
	}
}

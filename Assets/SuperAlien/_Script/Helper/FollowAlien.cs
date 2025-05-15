using UnityEngine;
using System.Collections;

public class FollowAlien : MonoBehaviour {
	public float smooth = 0.03f;
	private float threshold = 0.5f;
	public float offset = 3;
	public bool isFollow = true;
	public float speed = 8;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
//	void LateUpdate () {
//		float x = transform.position.x;
//
//		if (isFollow)
//			if (Mathf.Abs (x - Alien.position.x + offset) > threshold) 
//				x = Mathf.Lerp (x, Alien.position.x + offset, smooth);
//		else
//			x = x + speed * Time.deltaTime;
//
//		transform.position = new Vector3 (x, transform.position.y, transform.position.z);
//	}
	void LateUpdate () {
		float x = transform.position.x;
		
		if (isFollow)
		if (Mathf.Abs (x - GameManager.Instance.Player.transform.position.x + offset) > threshold) 
			x = Mathf.Lerp (x, GameManager.Instance.Player.transform.position.x + offset, smooth);
		else
			x = x + speed * Time.deltaTime;
		
		transform.position = new Vector3 (x, transform.position.y, transform.position.z);
	}
}

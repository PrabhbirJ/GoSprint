using UnityEngine;
using System.Collections;

public class ControllerInput : MonoBehaviour {

	public float sensor = 1.5f;

	bool isFirstTouch = false;
	Vector2 startPoint, currentPoint;
	float distanceWork = 0.1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.Instance.State != GameManager.GameState.Playing)
			return;


		if (Input.GetMouseButtonDown (0)) {
			isFirstTouch = true;
			startPoint = Normal(Input.mousePosition);

			StartCoroutine (CheckJump ());
		}

		if (isFirstTouch) {
			currentPoint = Normal(Input.mousePosition);



			if (Mathf.Abs (startPoint.x - currentPoint.x) > distanceWork * sensor) {
				if (currentPoint.x > startPoint.x)
					SwipeRight ();
				else
					SwipeLeft ();

				isFirstTouch = false;
			} else if (Mathf.Abs (startPoint.y - currentPoint.y) > distanceWork * sensor) {
				if (currentPoint.y > startPoint.y)
					SwipeUp ();
				else
					SwipeDown ();

				isFirstTouch = false;
			}
		}

		if (Input.GetMouseButtonUp (0)) {
			isFirstTouch = false;
			JumpOff ();
		}

		if (Input.GetMouseButton (0) && GameManager.Instance.Player.isUsingJetpack) {
			GameManager.Instance.Player.JetPack ();
		}
	}

	IEnumerator CheckJump(){
		yield return new WaitForSeconds (0.035f);

		if (Vector2.Distance (startPoint, currentPoint) < 0.005f)
			Jump ();
	}

	private void SwipeRight(){
		GameManager.Instance.Player.Boost (GlobalValue.BoostDistance, false);
	}

	private void SwipeLeft(){
	}

	private void SwipeUp (){
	}

	private void SwipeDown(){
		GameManager.Instance.Player.JumpDown ();
	}

	private void Jump(){
		GameManager.Instance.Player.Jump ();
	}

	private void JumpOff(){
		GameManager.Instance.Player.JumpOff ();
	}

	private Vector2 Normal(Vector2 vector2){
		Vector2 vec2 = Vector2.zero;
		vec2.x = (vector2.x / Screen.width);
		vec2.y = (vector2.y / Screen.height);

		return vec2;
	}


}

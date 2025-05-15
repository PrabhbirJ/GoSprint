using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu_EnergyBar : MonoBehaviour {

	public static MainMenu_EnergyBar Instance;

	public Transform Fill;
	public Transform StarHeader;
	public Animator StarHeaderAnim;

	[HideInInspector]
	public bool isBoostReady = false;
	[HideInInspector]
	public int starFull;
	[HideInInspector]
	public int starCount;

	// Use this for initialization
	void Start () {
		Instance = this;

		starFull = GameManager.Instance.starCollectedToBoost;
		starCount = 0;

		Fill.localScale = new Vector3 (0, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		var percent = (float)((float) Mathf.Clamp (starCount, 0, starFull) / (float)starFull);
		Fill.localScale = new Vector3 (percent, 1, 1);


		isBoostReady = starCount >= starFull ? true : false;
		StarHeaderAnim.SetBool ("allowBoost", isBoostReady);
	}

	public void CollectStar(){
		StarHeaderAnim.SetTrigger ("Collected");
		starCount++;
	}
}

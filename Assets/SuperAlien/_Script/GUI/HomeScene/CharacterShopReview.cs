using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterShopReview : MonoBehaviour {

	public SpriteRenderer Glass;
	public SpriteRenderer Hat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var choosenGlass = GlobalValue.ChoosenGlass;
		var choosenHat = GlobalValue.ChoosenHat;

		Glass.sprite = ClothHandle.Instance.GetGlassImage (choosenGlass);
		Hat.sprite = ClothHandle.Instance.GetHatImage (choosenHat);
	}
}

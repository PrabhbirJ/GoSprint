using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class HomeMenu_Shop : MonoBehaviour {
	//	public Transform BlockLevel;
	public RectTransform BlockLevel;
	public int howManyBlocks = 3;

	public float step = 720f;
	[HideInInspector]
	public bool sliding = false;
	private float smooth = 10f;
	private float newPosX = 0;
	// Use this for initialization

	void OnDisable() {
		newPosX = 0;	//because the Shop is located at last
		newPosX = Mathf.Clamp (newPosX, -step * (howManyBlocks-1), 0);
		sliding = true;
	}

	// Update is called once per frame
	void Update () {
		if (sliding) {
			float X = Mathf.Lerp (BlockLevel.anchoredPosition.x, newPosX, smooth * Time.deltaTime);
			BlockLevel.anchoredPosition = new Vector2 (X, BlockLevel.anchoredPosition.y);
			if (Mathf.Abs (BlockLevel.anchoredPosition.x - newPosX) < 10) {
				BlockLevel.anchoredPosition = new Vector2 (newPosX, BlockLevel.anchoredPosition.y);
				sliding = false;
			}
		}
	}
	
	public void Next(){
		if (!sliding) {
			newPosX -= step;
			newPosX = Mathf.Clamp (newPosX, -step * (howManyBlocks-1), 0);
			sliding = true;
		}
	}

	public void Pre(){
		if (!sliding) {
			newPosX += step;
			newPosX = Mathf.Clamp (newPosX, -step * (howManyBlocks-1), 0);
			sliding = true;
		}
	}

	public void OpenShopStar(bool force){
		if (!sliding || force) {
			newPosX -= int.MaxValue;	//because the Shop is located at last
			newPosX = Mathf.Clamp (newPosX, -step * (howManyBlocks-1), 0);
			sliding = true;
		}
	}

	public void OpenShopCloth(){
		
			newPosX = -1600;	//because the Shop is located at last
			newPosX = Mathf.Clamp (newPosX, -step * (howManyBlocks-1), 0);
			sliding = true;

	}

	public void OpenShopHeart(){

		newPosX = -3200;	//because the Shop is located at last
		newPosX = Mathf.Clamp (newPosX, -step * (howManyBlocks-1), 0);
		sliding = true;

	}


}

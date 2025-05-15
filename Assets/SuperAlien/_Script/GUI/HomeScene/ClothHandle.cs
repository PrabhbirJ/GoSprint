using UnityEngine;
using System.Collections;

public class ClothHandle : MonoBehaviour {
	public static ClothHandle Instance;

	public Sprite[] Glasses;
	public Sprite[] Hat;

	void Awake(){
		if (ClothHandle.Instance != null) {
			Destroy (gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad (gameObject);
	}

	//GLASSES HANDLE

	//check Unlocked or not
	public bool isGlassUnlocked(int ID){
		return PlayerPrefs.GetInt ("Glass" + ID, 0) == 0 ? false : true;
	}

	//Unlock the item
	public void UnlockGlass(int ID){
		PlayerPrefs.SetInt ("Glass" + ID, 1);
	}

	//Return the Sprite with the ID
	public Sprite GetGlassImage(int ID){
		if (ID > (Glasses.Length - 1)) {
//			Debug.LogError ("There are no item with this ID, please check the ID");
			return null;
		} else if (ID == -1)
			return null;

		return Glasses [ID];

	}


	//HAT HANDLE

	//check Unlocked or not
	public bool isHatUnlocked(int ID){
		return PlayerPrefs.GetInt ("Hat" + ID, 0) == 0 ? false : true;
	}

	//Unlock the item
	public void UnlockHat(int ID){
		PlayerPrefs.SetInt ("Hat" + ID, 1);
	}

	//Return the Sprite with the ID
	public Sprite GetHatImage(int ID){
		if (ID > (Hat.Length - 1)) {
//			Debug.LogError ("There are no item with this ID, please check the ID");
			return null;
		} else if (ID == -1)
			return null;

		return Hat [ID];

	}
}

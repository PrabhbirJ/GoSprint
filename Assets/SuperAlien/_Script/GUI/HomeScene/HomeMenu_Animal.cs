using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HomeMenu_Animal : MonoBehaviour {

	public AnimalName Animal;
	public Text saved;

	public Text nameTxt;
	public Image[] partBody;

	// Use this for initialization
	void Start () {
		saved.text = GlobalValue.GetSaved (Animal.animal.ToString ()) + "";

		if (GlobalValue.GetSaved (Animal.animal.ToString ()) == 0 && partBody.Length > 0) {
			nameTxt.text = "???";
			foreach (var image in partBody)
				image.color = Color.black;
		}
	}
}

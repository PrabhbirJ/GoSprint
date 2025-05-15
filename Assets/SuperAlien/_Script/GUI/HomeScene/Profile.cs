using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Profile : MonoBehaviour {

	public Text best;
	public Text animalSaved;
	public Text starEarned;
	public Text heartUsed;
	public Text rocketUsed;
	public Text gorillaUsed;
	public Text buffaloUsed;

	// Use this for initialization
	void Start () {
		best.text = GlobalValue.BestDistance + "";
		animalSaved.text = GlobalValue.TotalAnimal + "";
		starEarned.text = GlobalValue.TotalStarEarned + "";
		heartUsed.text = GlobalValue.TotalLivesUsed + "";
		rocketUsed.text = GlobalValue.TotalRocketUsed + "";
		gorillaUsed.text = GlobalValue.TotalGorillaUsed + "";
		buffaloUsed.text = GlobalValue.TotalBuffaloUsed + "";
	}
}

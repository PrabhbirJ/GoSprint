using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SaveMeContinues : MonoBehaviour {

	public GameObject ButtonSave;
	public Text heartTxt;
	bool isSave = false;
	bool outOfTime = false;
	int counter = 0;

	void OnEnable(){
		Debug.Log("accessed");
		
		    if(GlobalValue.SavedLives>=0)
			{
				StartCoroutine(GameoverCo ());
			
			}

		}
		
		
	

	// Use this for initialization
	void Start () {
		counter = GameManager.Instance.counter;
		Debug.Log("access");
		if (GlobalValue.SavedLives < 0) {
			GameManager.Instance.GameFinish (true);
			gameObject.SetActive (false);
		}
		

	}

	public void Save(){
		if (outOfTime)
		
			return;
		
		isSave = true;
		if (GlobalValue.SavedLives > 0)
		{
			GlobalValue.TotalLivesUsed++;
			GlobalValue.SavedLives--;
			GameManager.Instance.Continues();
			StopAllCoroutines();
			gameObject.SetActive(false);
		}
		else if(GlobalValue.SavedLives==0&&counter>0)
		{
			if(AdmobVNTIS_Interstitial._isAdLoaded())
			{
				GlobalValue.TotalLivesUsed++;

				GameManager.Instance.Continues();
				StopCoroutine(GameoverCo());
				AdmobVNTIS_Interstitial._showInterstitialImmediately();
				GameManager.Instance.counter -= 1;
				gameObject.SetActive(false);
			}
		
			
		}
		
	}

	IEnumerator GameoverCo(){
		heartTxt.text = 5 + "";
		yield return new WaitForSeconds(1); 
		heartTxt.text = 4 + "";
		yield return new WaitForSeconds(1);
		heartTxt.text = 3 + "";
		yield return new WaitForSeconds (1);
		heartTxt.text = 2 +"" ;
		yield return new WaitForSeconds (1);
		heartTxt.text = 1 + "";
		yield return new WaitForSeconds (1);
		outOfTime = true;
		HingeJoint2D[] HingeJoints = ButtonSave.GetComponents<HingeJoint2D> ();
		foreach (var hinge in HingeJoints) {
			hinge.enabled = false;
			yield return new WaitForSeconds (.2f);
		}

		yield return new WaitForSeconds (.7f);
		

		GameManager.Instance.GameFinish (true);
	}
}

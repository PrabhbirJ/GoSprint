using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveVisibility : MonoBehaviour {

	void OnEnable()
	{
		if (ShowAdRewarded.Instance.toRemove)
		{
			StartCoroutine(StopText());
		}
	}
	IEnumerator StopText()
	{
		yield return new WaitForSeconds(3);
		ShowAdRewarded.Instance.text.gameObject.SetActive(false);
	}
	
}

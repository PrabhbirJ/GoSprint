using UnityEngine;
using System.Collections;

public class PlatformGroup : MonoBehaviour {

	public Transform[] SpawnAnimalPoints;
	public GameObject[] Animals;
	[Range(0,100)]
	public float percentSpawn = 50;


	// Use this for initialization
	void Start () {
		if (SpawnAnimalPoints.Length < 1 || Animals.Length < 1) {
			Debug.LogWarning ("SpawnAnimalPoints or Animals must have at least 1 item");
			return;
		}
		if (Random.Range (0, 100) < percentSpawn) {
			var randPoint = SpawnAnimalPoints [Random.Range (0, SpawnAnimalPoints.Length)];
			var animal = Animals [Random.Range (0, Animals.Length)];
			Instantiate (animal, randPoint.position, Quaternion.identity);
		}
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireCube (transform.position, new Vector3 (22, 7.2f, 0));
	}
}

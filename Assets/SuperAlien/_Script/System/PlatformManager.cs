using UnityEngine;
using System.Collections;

public class PlatformManager : MonoBehaviour {
	public Transform SpawnPoint;
	public int MaxPlatform = 4;
	public int step = 22;
	public static PlatformManager Instance { get; private set; }
	GameObject Container;
	int currentPlatform = 0;

	public PlatformContainer[] Levels;

	public GameObject[] Tutorials;
	public int currentTutorial = 0;
	bool isCompleteTutorial;

	public int currentLevel = 0;

	// Use this for initialization
	void Start () {
		Instance = this;
		Container = Instantiate (new GameObject (), transform.position, transform.rotation) as GameObject;
		Container.name = "Container";


		SpawnPoint.position = Vector3.zero;

		isCompleteTutorial = GlobalValue.CompleteTutorial == 1 ? true : false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Container.transform.childCount < MaxPlatform) {
			Spawn ();
		}

		foreach (Transform child in Container.transform) {
			if ((child.position.x + step) < GameManager.Instance.Player.transform.position.x)
				Destroy (child.gameObject);
		}
	}

	private void Spawn(){
		var distance = GameManager.Instance.Distance;
		for (int i = 0; i < Levels.Length; i++) {
			if (Levels [i].activateDistance < distance && currentLevel < i) {
				currentLevel = i;
				break;
			}
		}

		var levelChoosen = Random.Range (0, currentLevel);

		SpawnPoint.position = new Vector3 (SpawnPoint.position.x + step, 0, 0);
		currentPlatform++;
		var numPlatform = Levels [levelChoosen].Platforms.Length;

		GameObject platformSpawn;
		if (isCompleteTutorial || Tutorials.Length == 0 || currentTutorial >= (Tutorials.Length))
			platformSpawn = Levels [levelChoosen].Platforms [Random.Range (0, numPlatform)];
		else {
			platformSpawn = Tutorials [currentTutorial];
			currentTutorial++;
		}
			
		var platform = Instantiate (platformSpawn, SpawnPoint.position, SpawnPoint.rotation) as GameObject;
		platform.transform.SetParent (Container.transform,true);
	}

	[System.Serializable]
	public class PlatformContainer{
		public int activateDistance = 0;
		public GameObject[] Platforms;
	}

}


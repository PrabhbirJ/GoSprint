using UnityEngine;
using System.Collections;

public class GameManager: MonoBehaviour {
	public static GameManager Instance{ get; private set;}
	public int counter = 3;
	public enum GameState{Menu,Playing, Dead, Finish, Pause};
	public GameState State{ get; set; }		//telling the state of the game

	[Header("Energy Boost")]
	public int starCollectedToBoost = 20;		//how many stars that the player need to collect to able use the boost feture

	public Player Player{ get; set;}		
	public EvilAlien EvilAlien{ get; set;}

	public int Distance{ get; set; }		//the distance of the player compare with the begin position
	[HideInInspector]
	public int startDistance;		//start position

	void Awake(){
		Instance = this;
		State = GameState.Menu;		//set the first state when begin the game is Menu
	}
//
//
//	public int Point{ get; set; }
//	int savePointCheckPoint;

	public int Star{ get; set; }		//public Star counter

	public int Animal{ get; set; }		//public Animal counter




	void Start(){
//		menuManager = FindObjectOfType<MenuManager> ();

		Star = GlobalValue.SavedStar;       //get the saved stars
		counter = 3;
		Debug.Log(counter+"counter ");

	}

	void Update(){
		if (GlobalValue.CompleteTutorial == 1)
			Distance = Mathf.Max ((int)Player.transform.position.x - startDistance, 0);
	}

//	public void ShowFloatingText(string text, Vector2 positon, Color color){
//		GameObject floatingText = Instantiate (FloatingText) as GameObject;
//		var _position = Camera.main.WorldToScreenPoint (positon);
//
//		floatingText.transform.SetParent (menuManager.transform,false);
//		floatingText.transform.position = _position;
//			
//		var _FloatingText = floatingText.GetComponent<FloatingText> ();
//		_FloatingText.SetText (text, color);
//	}

	//Call by MenuManager.cs
	public void StartGame(){
//		AdsController.HideAds ();

		State = GameState.Playing;	//set the state to Playing
		Player.Play ();		//Allow the player moving
		if (EvilAlien != null)
			EvilAlien.Play ();		//allow the EvilAlien chase the player

		startDistance = (int)Player.transform.position.x;		//get the begin position of the Player
	}

	//Call by Player.cs when the player hit the obstacles...
	public void GameOver(){
//		AdsController.ShowAds ();
   
		if (Distance > GlobalValue.BestDistance)
			GlobalValue.BestDistance = Distance;
		if (GlobalValue.SavedLives > 0 || (GlobalValue.SavedLives == 0 && counter > 0))
			MenuManager.Instance.OpenSaveMe();     //ask if the user want to be saved by using the heart live
		else
			GameFinish(true);
		State = GameState.Dead;		//set state to Dead
		Player.Dead ();		
		EvilAlien.Stop ();
		
			

	}

	//Game finish called by SaveMeContinues.cs
	//forceOver mean the GameOver panel will be shown immediately 
	public void GameFinish(bool forceOver){
		MenuManager.Instance.GameOver (forceOver);

		//save coins and points
		GlobalValue.SavedStar = Star;
//		GlobalValue.SavedPoints = Point;
	}

	//the player is saved by using the heart live item
	public void Continues(){
	//	AdsController.HideAds ();

		State = GameState.Playing;
		Player.Reborn ();
		EvilAlien.Play ();
	}
}

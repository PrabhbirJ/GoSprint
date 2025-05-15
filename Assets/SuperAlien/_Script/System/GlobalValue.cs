using UnityEngine;
using System.Collections;

public class GlobalValue : MonoBehaviour {
	public static int worldPlaying = 1;
	public static int levelPlaying = 1;

	public static bool openShop = false;

	public static string WorldReached = "WorldReached";
	public static string Star = "Star";
	public static string Lives = "Lives";
	public static string Points = "Points";
	public static string _BestDistance = "BestDistance";
	public static string Character = "Character";

	public static string _Boost1 = "Boost1";
	public static string _Boost2 = "Boost2";
	public static string _Boost3 = "Boost3";

	public static string _Gorilla = "Gorilla";
	public static string _Buffalo = "Buffalo";
	public static string _Rocket = "Rocket";
	public static string _DoubleStar = "DoubleStar";

	public static string _BoostDistance = "BoostDistance";
	public static string _RocketTime = "RocketTime";
	public static string _RocketCoolDownTime = "RocketCoolDownTime";
	public static string _GorillaTime = "GorillaTime";
	public static string _BuffaloTime = "BuffaloTime";

	public static string _ChoosenGlass = "ChoosenGlass";
	public static string _ChooseHat = "ChooseHat";

	public static string ChoosenCharacterID = "choosenCharacterID";
	public static string ChoosenCharacterInstanceID = "ChoosenCharacterInstanceID";
	public static GameObject CharacterPrefab;

	public static string _isCompleteTutorial = "CompleteTutorial";

	public static bool isSound = true;
	public static bool isMusic = true;
//	public static bool isRestart = false;

	//ANIMAL NAME
	public enum Animal{A,B,C};
	public static Animal animalName;

	public static int SavedLives{ 
		get { return PlayerPrefs.GetInt (GlobalValue.Lives, 3); } 
		set { PlayerPrefs.SetInt (GlobalValue.Lives, value); } 
	}
	public static int SavedStar{ 
		get { 
			if (!PlayerPrefs.HasKey (GlobalValue.Star))
				PlayerPrefs.SetInt (GlobalValue.Star, 300);

			return PlayerPrefs.GetInt (GlobalValue.Star, 0); } 
		set { PlayerPrefs.SetInt (GlobalValue.Star, value); } 
	}

	public static int BestDistance{ 
		get { return PlayerPrefs.GetInt (GlobalValue._BestDistance, 0); } 
		set { PlayerPrefs.SetInt (GlobalValue._BestDistance, value); } 
	}

	public static int SavedPoints { 
		get { return PlayerPrefs.GetInt (GlobalValue.Points, 0); } 
		set { PlayerPrefs.SetInt (GlobalValue.Points, value); } 
	}

	public static int ChoosenGlass { 
		get { return PlayerPrefs.GetInt (GlobalValue._ChoosenGlass, -1); } 
		set { PlayerPrefs.SetInt (GlobalValue._ChoosenGlass, value); } 
	}

	public static int ChoosenHat { 
		get { return PlayerPrefs.GetInt (GlobalValue._ChooseHat, -1); } 
		set { PlayerPrefs.SetInt (GlobalValue._ChooseHat, value); } 
	}

	public static int Boost1{ 
		get { 
			if(!PlayerPrefs.HasKey(_Boost1))
				PlayerPrefs.SetInt (_Boost1, 3);

			return PlayerPrefs.GetInt (_Boost1, 0); } 
		set { PlayerPrefs.SetInt (_Boost1, value); } 
	}

	public static int Boost2{ 
		get { 
			if(!PlayerPrefs.HasKey(_Boost2))
				PlayerPrefs.SetInt (_Boost2, 1);

			return PlayerPrefs.GetInt (_Boost2, 0); } 
		set { PlayerPrefs.SetInt (_Boost2, value); } 
	}

	public static int Boost3{ 
		get { 
			if(!PlayerPrefs.HasKey(_Boost3))
				PlayerPrefs.SetInt (_Boost3, 1);

			return PlayerPrefs.GetInt (_Boost3, 0); } 
		set { PlayerPrefs.SetInt (_Boost3, value); } 
	}

	public static int Gorilla{ 
		get { 
			if(!PlayerPrefs.HasKey(_Gorilla))
				PlayerPrefs.SetInt (_Gorilla, 3);

			return PlayerPrefs.GetInt (_Gorilla, 0); } 
		set { PlayerPrefs.SetInt (_Gorilla, value); } 
	}

	public static int Buffalo{ 
		get { 
			if(!PlayerPrefs.HasKey(_Buffalo))
				PlayerPrefs.SetInt (_Buffalo, 3);

			return PlayerPrefs.GetInt (_Buffalo, 0); } 
		set { PlayerPrefs.SetInt (_Buffalo, value); } 
	}

	public static int Rocket{ 
		get { 
			if(!PlayerPrefs.HasKey(_Rocket))
				PlayerPrefs.SetInt (_Rocket, 3);

			return PlayerPrefs.GetInt (_Rocket, 0); } 
		set { PlayerPrefs.SetInt (_Rocket, value); } 
	}

	public static int DoubleStar{ 
		get { 

			return PlayerPrefs.GetInt (_DoubleStar, 0);
		}
		set { PlayerPrefs.SetInt (_DoubleStar, value); } 
	}

	/////UPGRADE
	/// 
	/// 
	public static int BoostDistance{ 
		get { 
			if(!PlayerPrefs.HasKey(_BoostDistance))
				PlayerPrefs.SetInt (_BoostDistance, 10);

			return PlayerPrefs.GetInt (_BoostDistance, 0); } 
		set { PlayerPrefs.SetInt (_BoostDistance, value); } 
	}

	public static int RocketTime{ 
		get { 
			if(!PlayerPrefs.HasKey(_RocketTime))
				PlayerPrefs.SetInt (_RocketTime, 10);

			return PlayerPrefs.GetInt (_RocketTime, 0); } 
		set { PlayerPrefs.SetInt (_RocketTime, value); } 
	}

	public static int RocketCoolDownTime{ 
		get { 
			if(!PlayerPrefs.HasKey(_RocketCoolDownTime))
				PlayerPrefs.SetInt (_RocketCoolDownTime, 20);

			return PlayerPrefs.GetInt (_RocketCoolDownTime, 0); } 
		set { PlayerPrefs.SetInt (_RocketCoolDownTime, value); } 
	}

	public static int GorillaTime{ 
		get { 
			if(!PlayerPrefs.HasKey(_GorillaTime))
				PlayerPrefs.SetInt (_GorillaTime, 15);

			return PlayerPrefs.GetInt (_GorillaTime, 0); } 
		set { PlayerPrefs.SetInt (_GorillaTime, value); } 
	}

	public static int BuffaloTime{ 
		get { 
			if(!PlayerPrefs.HasKey(_BuffaloTime))
				PlayerPrefs.SetInt (_BuffaloTime, 15);

			return PlayerPrefs.GetInt (_BuffaloTime, 0); } 
		set { PlayerPrefs.SetInt (_BuffaloTime, value); } 
	}

	//

	public static void SetSaved(string nameAnimal){
		var amount = PlayerPrefs.GetInt (nameAnimal, 0);
		amount++;
		PlayerPrefs.SetInt (nameAnimal, amount);
	} 

	public static int GetSaved(string nameAnimal){

		return PlayerPrefs.GetInt (nameAnimal, 0);
	} 

	public static int CompleteTutorial{ 
		get {
			return PlayerPrefs.GetInt (_isCompleteTutorial, 0);
		}
		set { PlayerPrefs.SetInt (_isCompleteTutorial, value); }
	}

	//For Profile
	public static int TotalAnimal{ 
		get {
			return PlayerPrefs.GetInt ("TotalAnimal", 0);
		}
		set { PlayerPrefs.SetInt ("TotalAnimal", value); }
	}

	public static int TotalStarEarned{ 
		get {
			return PlayerPrefs.GetInt ("TotalStarEarned", 0);
		}
		set { PlayerPrefs.SetInt ("TotalStarEarned", value); }
	}

	public static int TotalLivesUsed{ 
		get {
			return PlayerPrefs.GetInt ("TotalLivesUsed", 0);
		}
		set { PlayerPrefs.SetInt ("TotalLivesUsed", value); }
	}

	public static int TotalRocketUsed{ 
		get {
			return PlayerPrefs.GetInt ("TotalRocketUsed", 0);
		}
		set { PlayerPrefs.SetInt ("TotalRocketUsed", value); }
	}

	public static int TotalGorillaUsed{ 
		get {
			return PlayerPrefs.GetInt ("TotalGorillaUsed", 0);
		}
		set { PlayerPrefs.SetInt ("TotalGorillaUsed", value); }
	}

	public static int TotalBuffaloUsed{ 
		get {
			return PlayerPrefs.GetInt ("TotalBuffaloUsed", 0);
		}
		set { PlayerPrefs.SetInt ("TotalBuffaloUsed", value); }
	}

	public static bool isFarmUnlocked{
		get{ return PlayerPrefs.GetInt ("isFarmUnlocked", 0) == 1 ? true : false; }
		set{ PlayerPrefs.SetInt ("isFarmUnlocked", value ? 1 : 0); }
	}

}

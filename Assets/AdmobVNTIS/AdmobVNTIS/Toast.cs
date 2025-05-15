using UnityEngine;

public class Toast {
	public static int LENGTH_LONG = 1;
	public static int LENGTH_SHORT = 0;
	public static void showText(string message,int duration){
		#if UNITY_EDITOR
		Debug.Log("Message toasted: " + message);
		return;
		#endif
		new AndroidJavaObject ("admob.admob",message,duration);
	}
}
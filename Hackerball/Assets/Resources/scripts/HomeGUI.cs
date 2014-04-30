using UnityEngine;
using System.Collections;

public class HomeGUI : MonoBehaviour {

	public GUIStyle guiStyle = new GUIStyle();
	public GUIStyle guiStyleWon = new GUIStyle ();

	private float screenWidth;
	private float resetHeight;
	private float resetWidth;

	private int progress;

	// Use this for initialization
	void Start () {
		progress = PlayerPrefs.GetInt ("level");
		screenWidth = Screen.width;
		resetHeight = 50;
		resetWidth = 200;
	}
	
	// Update is called once per frame
	void OnGUI () {
		if(GUI.Button(new Rect((screenWidth-resetWidth),10,resetWidth,resetHeight),"reset progress",guiStyle)){
			CurrentLevel.ResetLevels();
			CurrentLevel.InitLevels();
			Application.LoadLevel("LevelSelector");
		}
		if (progress > 9) {
			GUI.Label (new Rect (((screenWidth / 2) - (resetWidth / 2)), 10, resetWidth, resetHeight), "You've won", guiStyleWon);
		}


	}
}

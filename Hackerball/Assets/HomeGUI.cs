using UnityEngine;
using System.Collections;

public class HomeGUI : MonoBehaviour {

	public GUIStyle guiStyle = new GUIStyle();

	private float screenWidth;
	private float resetHeight;
	private float resetWidth;

	// Use this for initialization
	void Start () {
		screenWidth = Screen.width;
		resetHeight = 50;
		resetWidth = 200;
	}
	
	// Update is called once per frame
	void OnGUI () {
		if(GUI.Button(new Rect((screenWidth-resetWidth),10,resetWidth,resetHeight),"reset progress",guiStyle)){
			CurrentLevel.ResetLevels();
			CurrentLevel.InitLevels();
		}
	}
}

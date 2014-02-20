using UnityEngine;
using System.Collections;

public class GuiTextTimer : MonoBehaviour {
	public float counter;
	public GUIStyle guiStyle = new GUIStyle();
	public int warningFontSize;
	int seconds;

	void OnGUI(){
		GUI.Label(new Rect(0,0,100,75),seconds.ToString(),guiStyle);
	}

	void Update(){
		if (counter > 0) {
			counter -= Time.deltaTime;
			seconds = (int)counter;
			if(counter < 10){
				guiStyle.normal.textColor = new Color(255,0,0);
				guiStyle.fontSize = warningFontSize;
			}
		}
	}
	
}

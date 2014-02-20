using UnityEngine;
using System.Collections;

public class GuiTextTimer : MonoBehaviour {
	float Counter = 0;
	int Seconds;

	void OnGUI(){
		Counter += Time.deltaTime;
		Seconds = (int)Counter % 60;
		GUI.Box(new Rect(0,0,100,75),Seconds.ToString());
	}
}

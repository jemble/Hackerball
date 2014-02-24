using UnityEngine;
using System.Collections;

public class PauseAll : MonoBehaviour {
	private bool isPaused = false;
	public string pauseKey;
	//public GuiTextTimer guiTextTimer;
	private Object[] gOs;

	// Use this for initialization
	void Start () {
		gOs = FindObjectsOfType (typeof(GameObject));

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (pauseKey)) {
			pauseGo();
		}
	}

	public void pauseGo(){
		if (!isPaused) {
			Time.timeScale = 0;
			isPaused = true;

		} else {
			Time.timeScale = 1;
			isPaused = false;
		}
		foreach (GameObject gO in gOs) {
			gO.SendMessage("setPause",isPaused,SendMessageOptions.DontRequireReceiver);
		}
		//guiTextTimer.setPaused(isPaused);
	}
}

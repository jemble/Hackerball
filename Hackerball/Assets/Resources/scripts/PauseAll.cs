using UnityEngine;
using System.Collections;

public class PauseAll : MonoBehaviour {
	private bool isPaused = false;
	public string pauseKey;
	//public GuiTextTimer guiTextTimer;
	private Object[] gOs;
	private GameState.State curState;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (pauseKey)) {
			//GameState.ChangeState(GameState.State.Paused);
			pauseGo();
		}
	}

	public void pauseGo(){
		if (!isPaused) {
			curState = GameState.CurrentState;
			Time.timeScale = 0;
			isPaused = true;
			GameState.ChangeState(GameState.State.Paused);

		} else {
			GameState.ChangeState(curState);
			Time.timeScale = 1;
			isPaused = false;
		}
	}
}

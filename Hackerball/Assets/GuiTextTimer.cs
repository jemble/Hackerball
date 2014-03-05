using UnityEngine;
using System.Collections;

public class GuiTextTimer : MonoBehaviour {
	public float counter;
	public GUIStyle guiStyleTimer = new GUIStyle();
	public GUIStyle guiStyleMenu = new GUIStyle();
	public int warningFontSize;
	int seconds;
	bool isPaused;
	public PauseAll pA;

	private GameObject ball;

	private float screenHeight;
	private float screenXCentre;
	private float screenYCentre;
	private float timerBoxHeight;
	private float timerBoxWidth;


	void Start(){

		timerBoxWidth = 300;
		timerBoxHeight = 100;
		screenXCentre = Screen.width/2;
		screenYCentre = Screen.height/2;
		screenHeight = Screen.height;

		ball = GameObject.FindGameObjectWithTag("Player");
	}

	public void GameRunning(){
		GUI.Label(new Rect(screenXCentre-(timerBoxWidth/2),(screenHeight-timerBoxHeight),timerBoxWidth,timerBoxHeight),seconds.ToString(),guiStyleTimer);
		if (counter < 0) {
			GameState.ChangeState(GameState.State.End);
		}
	}

	private void GameEnded(){
		if(ball != null){
			Object explode = Instantiate(Resources.Load("ParticleSystem"),ball.transform.position,ball.transform.rotation);
			Destroy(ball.gameObject);
		}
		if(GUI.Button(new Rect(screenXCentre-(timerBoxWidth/2),(screenYCentre-timerBoxHeight),timerBoxWidth,timerBoxHeight),"restart",guiStyleMenu)){
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	public void GamePaused(){
		Debug.Log ("paused");
		if (GUI.Button(new Rect(screenXCentre-(timerBoxWidth/2),(screenYCentre-timerBoxHeight),timerBoxWidth,timerBoxHeight),"continue",guiStyleMenu)) {
			GameState.ChangeState(GameState.State.Running);	
			pA.pauseGo();
		}
	}


	void OnGUI(){
		GameState.State gameState = GameState.CurrentState;
		switch(gameState){
		case GameState.State.Running:
			GameRunning();
			break;
		case GameState.State.Paused:
			GamePaused();
			break;
		case GameState.State.End:
			GameEnded();
			break;
		}
	}

	void Update(){
		if (counter > 0) {
			counter -= Time.deltaTime;
			seconds = (int)counter;
			if(counter < 10){
				guiStyleTimer.normal.textColor = new Color(255,0,0);
				guiStyleTimer.fontSize = warningFontSize;
			}
		}

	}
}

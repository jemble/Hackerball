using UnityEngine;
using System.Collections;

public class GuiTextTimer : MonoBehaviour {

	//used to set PlayerPrefs best score
	private string SCORE_KEY = "SCORE_KEY";

	//used to set playerprefs
	public int level;

	public float counter;
	public GUIStyle guiStyleTimer = new GUIStyle();
	public GUIStyle guiStyleMenu = new GUIStyle();
	public GUIStyle guiStyleScore = new GUIStyle();

	public int warningFontSize;
	int seconds;
	private float startTime;
	bool isPaused;
	public PauseAll pA;
	private int bestTime = 0;


	private GameObject ball;

	private float screenHeight;
	private float screenXCentre;
	private float screenYCentre;
	private float timerBoxHeight;
	private float timerBoxWidth;


	void Start(){
		startTime = counter;
		timerBoxWidth = 300;
		timerBoxHeight = 100;
		screenXCentre = Screen.width/2;
		screenYCentre = Screen.height/2;
		screenHeight = Screen.height;

		SCORE_KEY = SCORE_KEY+level.ToString();

		Debug.Log(SCORE_KEY);
		if(PlayerPrefs.HasKey(SCORE_KEY)){
			bestTime = PlayerPrefs.GetInt(SCORE_KEY);
			Debug.Log(bestTime);
		}
		ball = GameObject.FindGameObjectWithTag("Player");
	}

	public void GameRunning(){
		GUI.Label(new Rect(screenXCentre-(timerBoxWidth/2),(screenHeight-timerBoxHeight),timerBoxWidth,timerBoxHeight),seconds.ToString(),guiStyleTimer);
		if (counter < 0) {
			GameState.ChangeState(GameState.State.End);
		}
		GUI.Label(new Rect(0,screenHeight-timerBoxHeight,timerBoxWidth,timerBoxHeight),"best: "+bestTime.ToString(),guiStyleTimer);
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

	public void GameWon(){
		int curBestTime = (int)(startTime-counter);
		Debug.Log ("curBestTime: "+curBestTime);
		if(curBestTime<bestTime || bestTime==0){
			Debug.Log("setting prefs");
			PlayerPrefs.SetInt(SCORE_KEY,curBestTime);
		}
	}
	public void GameWinning(){

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
		case GameState.State.Winning:
			GameRunning();
			GameWinning ();
			break;
		case GameState.State.Won:
			GameWon();
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

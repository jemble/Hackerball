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

	void OnGUI(){
		GUI.Label(new Rect(screenXCentre-(timerBoxWidth/2),(screenHeight-timerBoxHeight),timerBoxWidth,timerBoxHeight),seconds.ToString(),guiStyleTimer);
		if (isPaused) {
			if (GUI.Button(new Rect(screenXCentre-(timerBoxWidth/2),(screenYCentre-timerBoxHeight),timerBoxWidth,timerBoxHeight),"continue",guiStyleMenu)) {
				pA.pauseGo ();
			}
		}
		if(counter < 0){
//			Time.timeScale = 0;
//			gOs = FindObjectsOfType (typeof(GameObject));
//			foreach(GameObject go in gOs){
//				Object explode = Instantiate(Resources.Load("ParticleSystem"),go.transform.position,go.transform.rotation);
//				//Destroy (go.gameObject);
//			} 

			if(ball != null){
				Object explode = Instantiate(Resources.Load("ParticleSystem"),ball.transform.position,ball.transform.rotation);
				Destroy(ball.gameObject);
			}
			if(GUI.Button(new Rect(screenXCentre-(timerBoxWidth/2),(screenYCentre-timerBoxHeight),timerBoxWidth,timerBoxHeight),"restart",guiStyleMenu)){
				Application.LoadLevel(Application.loadedLevel);
			}
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

	public void setPause(bool pauseState){
		isPaused = pauseState;
	}
	
}

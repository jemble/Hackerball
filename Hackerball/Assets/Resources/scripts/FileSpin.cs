using UnityEngine;
using System.Collections;

public class FileSpin : MonoBehaviour {

	public float rotationSpeed = 75;
	public float bounceSpeed = 5;
	public float bounceHeight = 10;

	private float currentBounce = 0;
	private bool up = true;

	private Vector3 screenPosOnceGot = new Vector3(Screen.width-50,Screen.height-50,20);

	// Use this for initialization
	void Start () {
	
	}

	private void TwirlAndBounce(){
		float bounce;
		if(up) {
			bounce = bounceSpeed * Time.deltaTime; 
		} else {
			bounce = -bounceSpeed * Time.deltaTime; 
		}
		
		currentBounce += bounce;
		
		if(currentBounce > bounceHeight) up = false;
		if(currentBounce < -bounceHeight) up = true ;
		
		this.gameObject.transform.Translate(0,bounce,0);
		
		this.gameObject.transform.Rotate(new Vector3(0,(Time.deltaTime * rotationSpeed),0));
	}

	private void MoveToScreenPos(){
		this.gameObject.transform.position = Camera.main.ScreenToWorldPoint (screenPosOnceGot);
	}

	// Update is called once per frame
	void Update () {
		GameState.State state = GameState.CurrentState;
		switch (state) {
		case GameState.State.Running:
			TwirlAndBounce();
			break;
		case GameState.State.Winning:
			TwirlAndBounce();
			MoveToScreenPos();
			break;
		}
	}

	void LateUpdate(){

	}
}

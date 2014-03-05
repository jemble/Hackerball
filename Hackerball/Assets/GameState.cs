using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	public enum State {Paused, Running, End};
	public static State CurrentState;

	public static void ChangeState(State state){
		CurrentState = state;
		//Debug.Log ("state: " + CurrentState.ToString ());
	}

	// Use this for initialization
	void Start () {
		CurrentState = State.Running;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;

public class MoveCam : MonoBehaviour {

	public GameObject player;
	public float zoomSpeed = 2.0f;
	public float turnSpeed = 2.0f;
	public float verticalSpeed = 0.5f;
	float rotPointX;
	float rotPointY = 0.0f;
	float rotPointZ;

	//rotPoint is basically the position of the ball ignoring the y axis
	Vector3 rotPoint;
	
	//the mouse position and scroll amount
	float mouseX;
	float mouseY;
	float mouseScr;

	//the rotation of the camera around y axis
	float camRotY;

	//starting pos and rotation of the camera
	public Vector3 startPos = new Vector3(-10,20,0);
	public float startYRot = 45;
	
	// Use this for initialization
	void Start () {
		rotPoint = new Vector3 ();
		rotPoint.y = rotPointY;
		camRotY = transform.eulerAngles.y;
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void GameRunning(){
		if (player != null) {
			//get the ball pos
			rotPoint.x = player.transform.position.x;
			rotPoint.z = player.transform.position.z;
			
			//get the mouse pos and scroll amount
			mouseX = Input.GetAxis ("Mouse X");
			mouseScr = Input.GetAxis ("Mouse ScrollWheel");
			
			//zoom the field of view based on the scroll
			camera.fieldOfView += mouseScr * zoomSpeed;
			
			//point the camera at the x and z of the ball
			transform.LookAt (rotPoint);
			
			//rotate around the x and z of the ball using the mouse
			transform.RotateAround (rotPoint, Vector3.up, mouseX * turnSpeed);
			
			//get the camera's rotation around y
			camRotY = transform.eulerAngles.y;
			
			//rotate the ball with the camera so that forward key is still forward 
			player.transform.eulerAngles = new Vector3 (0, camRotY, 0);

			//get the camera's position
			Vector3 camPos = transform.position;

			if (Input.GetMouseButton(1)){
				if (rotPoint.y < 10){
					rotPoint.y = rotPoint.y + verticalSpeed;
					camPos.y = camPos.y + verticalSpeed;
					transform.position = camPos;
				}
			}
			else if (Input.GetMouseButton(0)){
				if (rotPoint.y > 0){
					rotPoint.y = rotPoint.y - verticalSpeed;
					camPos.y = camPos.y - verticalSpeed;
					transform.position = camPos;
				}
			}
			
			//		Debug.Log ("ball rot: "+ player.transform.rotation.y);
			//		Debug.Log ("cam rot: "+transform.rotation.y);
			
		}
	}

	//late update used as the camera is following the ball
	void LateUpdate(){
		GameState.State gameState = GameState.CurrentState;
		switch(gameState){
		case GameState.State.Running:
			GameRunning();
			break;
		case GameState.State.Winning:
			GameRunning();
			break;
		case GameState.State.Paused:
			break;
		case GameState.State.End:
			break;
		}
	}
}

//x and z of ball but y=0
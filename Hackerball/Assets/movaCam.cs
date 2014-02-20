using UnityEngine;
using System.Collections;

public class movaCam : MonoBehaviour {

	public GameObject player;
	public float zoomSpeed = 2.0f;
	public float leftSpeed = 2.0f;
	public float upSpeed = 2.0f;

	float rotPointX;
	float rotPointY = 0.0f;
	float rotPointZ;
	Vector3 rotPoint;
	float mouseX;
	float mouseY;
	float mouseScr;
	float camRotY;

	Vector3 startPos = new Vector3(-10,20,0);
	float startYRot = 45;

	// Use this for initialization
	void Start () {
		rotPoint = new Vector3 ();
		rotPoint.y = rotPointY;
		camRotY = transform.eulerAngles.y;
		//player.transform.Rotate (Vector3.up, camRotY);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void LateUpdate(){
//		rotPointX = player.transform.position.x;
//		rotPointZ = player.transform.position.z;
		rotPoint.x = player.transform.position.x;
		rotPoint.z = player.transform.position.z;

		mouseX = Input.GetAxis("Mouse X");
		mouseScr = Input.GetAxis ("Mouse ScrollWheel");

		camera.fieldOfView += mouseScr * zoomSpeed;

		transform.LookAt (rotPoint);
		transform.RotateAround(rotPoint,Vector3.up,mouseX * upSpeed);

		camRotY = transform.eulerAngles.y;

		//rotate the ball with the camera so that forward key is still forward 
		player.transform.eulerAngles = new Vector3 (0, camRotY, 0);

//		Debug.Log ("ball rot: "+ player.transform.rotation.y);
//		Debug.Log ("cam rot: "+transform.rotation.y);

	}

	public void ResetPos(){
		transform.position = startPos;
		transform.eulerAngles = new Vector3(0,startYRot,0);
	}
}

//x and z of ball but y=0
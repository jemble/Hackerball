using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	public float moveForce = 4.0f;        
	public float maxSpeed = 10f;
	public float bounceHeight = 100f;
	public Vector3 startPos;
	public float startRot;
	public MoveCam cam;
	private Vector3 v;
	private Vector3 bounce;

	private bool jump = false;

	// Use this for initialization
	void Start () {
		bounce = new Vector3 (0, bounceHeight, 0);
	}

	void Update () {

			v = new Vector3 (Input.GetAxis ("Horizontal"), 0.0f, Input.GetAxis ("Vertical"));
			if (transform.position.y < -10) {
				MoveToStart ();
				cam.ResetPos ();
		
		}
	
	}
	
	void FixedUpdate() {

			rigidbody.velocity = Vector3.ClampMagnitude (rigidbody.velocity, maxSpeed);
		//	rigidbody.AddForce(v.normalized * moveForce);

		//	camera.transform.TransformDirection(v);
			rigidbody.AddRelativeForce (v.normalized * moveForce);

			if (jump) {
				jump = false;
				rigidbody.AddForce (bounce);
			}

	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "boost") {
			jump = true;
		}
	}

	void MoveToStart(){
		transform.position = startPos;
		bounce = new Vector3 (0, bounceHeight, 0);
		jump = false;

	}
}

using UnityEngine;
using System.Collections;

public class MovingBlock : MonoBehaviour {
	Vector3 startPos;
	 
	public float xDistance = 10;
	public float yDistance = 10;
	public float zDistance = 10;
	public bool xMovement = true;
	public bool yMovement = true;
	public bool zMovement = true;
	private float posX, posY, posZ;
	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (xMovement == true) {
			posX = Mathf.PingPong (Time.time, xDistance);
		}
		else {
			posX = transform.position.x;
		}

		if (yMovement == true) {
			posY = Mathf.PingPong (Time.time, yDistance);
		}
		else {
			posY = transform.position.y;
		}

		if (zMovement == true) {
			posZ = Mathf.PingPong (Time.time, zDistance);
		}
		else {
			posZ = transform.position.z;
		}

		transform.position = new Vector3 (posX, posY, posZ);
	}
}

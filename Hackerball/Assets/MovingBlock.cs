using UnityEngine;
using System.Collections;

public class MovingBlock : MonoBehaviour {
	Vector3 startPos;
	 
	public float moveHeight = 10;
	private float posX, posZ;
	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		posX = transform.position.x;
		posZ = transform.position.z;
		transform.position = new Vector3 (posX, Mathf.PingPong (Time.time, moveHeight), posZ);
	}
}

using UnityEngine;
using System.Collections;

public class RetryLevel : MonoBehaviour {

	private int bounceCount = 0;
	public int maxBounces = 5;
	public string levelName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "Player") {
			bounceCount++;
			Debug.Log(bounceCount);
			if(bounceCount == maxBounces){
				Application.LoadLevel(levelName);
			}
		}
	}
}

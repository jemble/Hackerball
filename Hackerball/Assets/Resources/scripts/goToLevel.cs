using UnityEngine;
using System.Collections;

public class goToLevel : MonoBehaviour {

	public int level;
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
			Application.LoadLevel(levelName);
		}
	}
}

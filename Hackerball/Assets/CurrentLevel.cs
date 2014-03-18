using UnityEngine;
using System.Collections;

public class CurrentLevel : MonoBehaviour {
	private int level;
	// Use this for initialization
	void Start () {
		if(PlayerPrefs.HasKey("level")) {
			level = PlayerPrefs.GetInt("level");
		} else {
			PlayerPrefs.SetInt("level",0);
			level = 0;
		}

		Debug.Log(level);

		GameObject[] levelBeams = GameObject.FindGameObjectsWithTag("levelBeam");
		foreach (GameObject beam in levelBeams) {
			goToLevel goTo = beam.GetComponent<goToLevel>();
			if(goTo.level != level) {
				Destroy(beam);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

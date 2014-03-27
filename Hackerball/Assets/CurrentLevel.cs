using UnityEngine;
using System.Collections;

public class CurrentLevel : MonoBehaviour {
	private static int level;
	// Use this for initialization
	void Start () {
		InitLevels ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void ResetLevels(){
		PlayerPrefs.SetInt("level",0);
		level = 0;
	}

	public static void InitLevels(){
		if(PlayerPrefs.HasKey("level")) {
			level = PlayerPrefs.GetInt("level");
		} else {
			ResetLevels ();
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
}

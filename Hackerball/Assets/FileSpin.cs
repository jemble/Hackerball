using UnityEngine;
using System.Collections;

public class FileSpin : MonoBehaviour {

	public float rotationSpeed = 75;
	public float bounceSpeed = 5;
	public float bounceHeight = 10;

	private float currentBounce = 0;
	private bool up = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float bounce;
		if(up) {
			bounce = bounceSpeed * Time.deltaTime; 
		} else {
			bounce = -bounceSpeed * Time.deltaTime; 
		}

		currentBounce += bounce;

		if(currentBounce > bounceHeight) up = false;
		if(currentBounce < -bounceHeight) up = true ;

		this.gameObject.transform.Translate(0,bounce,0);

		this.gameObject.transform.Rotate(new Vector3(0,(Time.deltaTime * rotationSpeed),0));
	}
}

using UnityEngine;
using System.Collections;

public class floorscript : MonoBehaviour {

	public GameObject shadow;

	// Use this for initialization
	void Start () {
		//shadow = GameObject.FindGameObjectWithTag ("cyl");
	}
	
	// Update is called once per frame
	void LateUpdate () {
		// Ray ray = new Ray(this.gameObject.transform.position,Vector3.down);
		RaycastHit hit;
		if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.down),out hit,100f)) {
			shadow.transform.position = hit.point;
			shadow.renderer.enabled = true;
		} else {
			shadow.renderer.enabled = false;
		}

	}
}

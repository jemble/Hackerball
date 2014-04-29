using UnityEngine;
using System.Collections;

public class platformEroder : MonoBehaviour {

	public bool smashable = true;
	public int maxBounces = 9;

	private int bounceCounter = 0;

	void Start () {
		bounceCounter = maxBounces;
	}

	void OnCollisionEnter(Collision collision) {
		if (smashable) {
			if (collision.gameObject.tag == "Player") {
				bounceCounter--;
				switch (bounceCounter) {
					case 0:
						object explode = Instantiate(Resources.Load("ParticleSystem"),transform.position,transform.rotation);
						explode = true;
						Destroy (this.gameObject);
						break;
					case 1:
						renderer.material.mainTexture = Resources.Load ("CubeFaceCracked8") as Texture2D;
						break;
					case 2:
						renderer.material.mainTexture = Resources.Load ("CubeFaceCracked7") as Texture2D;
						break;
					case 3:
						renderer.material.mainTexture = Resources.Load ("CubeFaceCracked6") as Texture2D;
						break;
					case 4:
						renderer.material.mainTexture = Resources.Load ("CubeFaceCracked5") as Texture2D;
						break;
					case 5:
						renderer.material.mainTexture = Resources.Load ("CubeFaceCracked4") as Texture2D;
						break;
					case 6:
						renderer.material.mainTexture = Resources.Load ("CubeFaceCracked3") as Texture2D;
						break;
					case 7:
						renderer.material.mainTexture = Resources.Load ("CubeFaceCracked2") as Texture2D;
						break;
					case 8:
						renderer.material.mainTexture = Resources.Load ("CubeFaceCracked1") as Texture2D;
						break;
					default:
						renderer.material.mainTexture = Resources.Load ("CubeFace") as Texture2D;
						break;
				}
			}
		}
	}
}

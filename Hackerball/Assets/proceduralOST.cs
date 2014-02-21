using UnityEngine;
using System.Collections;

public class proceduralOST : MonoBehaviour {

	public int longDuration = 6;
	public int shortDuration = 4;
	private bool repeatShort = true;

	void Start () {
		StartCoroutine ("pickNewLong");
		pickNewSample ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void pickNewSample(){
		int longOrShort = UnityEngine.Random.Range (0, 1);
		if (longOrShort == 0) {
			StartCoroutine("pickNewShort");
		}
		if (longOrShort == 1) {
			StartCoroutine("pickNewLong");
		}
	}

	IEnumerator pickNewLong(){
		int whichLong = UnityEngine.Random.Range (0, 7);
		AudioClip longSample;

		switch (whichLong) {
			case 0:
				//Ab
				longSample = Resources.Load ("Ab") as AudioClip;
				break;
			case 1:
				//AbMaj7
				longSample = Resources.Load ("AbMaj7") as AudioClip;
				break;
			case 2:
				//Bb
				longSample = Resources.Load ("Bb") as AudioClip;;
				break;
			case 3:
				//Cm
				longSample = Resources.Load ("Cm") as AudioClip;
				break;
			case 4:
				//Eb
				longSample = Resources.Load ("Eb") as AudioClip;
				break;
			case 5:
				//EbMaj7
				longSample = Resources.Load ("EbMaj7") as AudioClip;
				break;
			case 6:
				//Fm
				longSample = Resources.Load ("Fm") as AudioClip;
				break;
			case 7:
				//Gm
				longSample = Resources.Load ("Gm") as AudioClip;
				break;
			default:
				//Cm
				longSample = Resources.Load ("Cm") as AudioClip;
				break;
		}
		AudioSource.PlayClipAtPoint(longSample, transform.position);
		yield return new WaitForSeconds(longDuration);
		pickNewSample();
	}

	IEnumerator pickNewShort(){
		int whichShort = UnityEngine.Random.Range (0, 6);
		AudioClip shortSample;

		switch (whichShort) {
		case 0:
			//AbMaj7 Short
			shortSample = Resources.Load ("AbMaj7-Short") as AudioClip;
			break;
		case 1:
			//Bb Short
			shortSample = Resources.Load ("Bb-Short") as AudioClip;
			break;
		case 2:
			//Cm Short
			shortSample = Resources.Load ("Cm-Short") as AudioClip;;
			break;
		case 3:
			//Eb Short
			shortSample = Resources.Load ("Eb-Short") as AudioClip;
			break;
		case 4:
			//EbMaj7 Short
			shortSample = Resources.Load ("EbMaj7-Short") as AudioClip;
			break;
		case 5:
			//Fm Short
			shortSample = Resources.Load ("Fm-Short") as AudioClip;
			break;
		case 6:
			//Gm Short
			shortSample = Resources.Load ("Gm-Short") as AudioClip;
			break;
		default:
			//EbMaj7Short
			shortSample = Resources.Load ("EbMaj7-Short") as AudioClip;
			break;
		
		}
		AudioSource.PlayClipAtPoint(shortSample, transform.position);
		yield return new WaitForSeconds(shortDuration);

		if (repeatShort) {
			StartCoroutine ("pickNewShort");
			repeatShort = false;
		}
		else {
			pickNewSample ();
			repeatShort = true;
		}
	}
}

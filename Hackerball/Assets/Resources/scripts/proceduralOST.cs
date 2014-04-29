using UnityEngine;
using System.Collections;

public class proceduralOST : MonoBehaviour {

	public int longDuration = 6;
	public int shortDuration = 4;
	public int shortVsLongThreshold = 4;
	public float musicVolume = 0.2f;
	private bool repeatShort = true;

	void Start () {
		StartCoroutine ("pickNewLong");
		pickNewSample ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void pickNewSample(){
		int longOrShort = UnityEngine.Random.Range (0, 6);
		if (longOrShort <= shortVsLongThreshold) {
			StartCoroutine("pickNewLong");
		}
		else {
			StartCoroutine("pickNewShort");
		}
	}

	IEnumerator pickNewLong(){
		int whichLong = UnityEngine.Random.Range (0, 7);
		AudioClip longSample;

		switch (whichLong) {
			case 0:
				//Ab
				longSample = Resources.Load ("sounds/Ab") as AudioClip;
				break;
			case 1:
				//AbMaj7
			longSample = Resources.Load ("sounds/AbMaj7") as AudioClip;
				break;
			case 2:
				//Bb
			longSample = Resources.Load ("sounds/Bb") as AudioClip;;
				break;
			case 3:
				//Cm
			longSample = Resources.Load ("sounds/Cm") as AudioClip;
				break;
			case 4:
				//Eb
			longSample = Resources.Load ("sounds/Eb") as AudioClip;
				break;
			case 5:
				//EbMaj7
			longSample = Resources.Load ("sounds/EbMaj7") as AudioClip;
				break;
			case 6:
				//Fm
			longSample = Resources.Load ("sounds/Fm") as AudioClip;
				break;
			case 7:
				//Gm
			longSample = Resources.Load ("sounds/Gm") as AudioClip;
				break;
			default:
				//Cm
			longSample = Resources.Load ("sounds/Cm") as AudioClip;
				break;
		}
		AudioSource.PlayClipAtPoint(longSample, transform.position, musicVolume);
		yield return new WaitForSeconds(longDuration);
		pickNewSample();
	}

	IEnumerator pickNewShort(){
		int whichShort = UnityEngine.Random.Range (0, 6);
		AudioClip shortSample;

		switch (whichShort) {
		case 0:
			//AbMaj7 Short
			shortSample = Resources.Load ("sounds/AbMaj7-Short") as AudioClip;
			break;
		case 1:
			//Bb Short
			shortSample = Resources.Load ("sounds/Bb-Short") as AudioClip;
			break;
		case 2:
			//Cm Short
			shortSample = Resources.Load ("sounds/Cm-Short") as AudioClip;;
			break;
		case 3:
			//Eb Short
			shortSample = Resources.Load ("sounds/Eb-Short") as AudioClip;
			break;
		case 4:
			//EbMaj7 Short
			shortSample = Resources.Load ("sounds/EbMaj7-Short") as AudioClip;
			break;
		case 5:
			//Fm Short
			shortSample = Resources.Load ("sounds/Fm-Short") as AudioClip;
			break;
		case 6:
			//Gm Short
			shortSample = Resources.Load ("sounds/Gm-Short") as AudioClip;
			break;
		default:
			//EbMaj7Short
			shortSample = Resources.Load ("EbMaj7-Short") as AudioClip;
			break;
		
		}
		AudioSource.PlayClipAtPoint(shortSample, transform.position, musicVolume);
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

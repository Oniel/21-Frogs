using UnityEngine;
using System.Collections;

public class SplashScreenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("SplashScreenWait");
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetAxisRaw ("Fire1") > 0 && Application.loadedLevel == 1) {
			Application.LoadLevel (2);
		}
	}

	IEnumerator SplashScreenWait () {
		if (Application.loadedLevel == 0) {
			yield return new WaitForSeconds (3);
			Application.LoadLevel (1);
		} else if (Application.loadedLevel == 1) {
			yield return new WaitForSeconds (7);
			Application.LoadLevel (2);
		}
	}
}

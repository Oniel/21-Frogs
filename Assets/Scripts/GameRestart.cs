using UnityEngine;
using System.Collections;

public class GameRestart : MonoBehaviour {

	public float restartWaitTime;
	bool canGameRestart = false;
	float restartTime;


	// sets the game restart time (after player death or game has been won)
	public void gameRestart () {
		canGameRestart = true;
		restartTime = Time.time + restartWaitTime;
	}

	// reload the level
	void Update () {
		if (canGameRestart && restartTime <= Time.time) {
			Application.LoadLevel (Application.loadedLevel);
		}
	}


}

using UnityEngine;
using System.Collections;

public class ScrollGameObjScript : MonoBehaviour {

	public float scrollSpeed = 0;

	// moves gameObjects to the left (to be destroyed offscreen by Destroyers)
	void Update () {
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (Time.time * scrollSpeed, 0f);
		transform.position = new Vector2 (Time.time * -scrollSpeed, 0f);
	}

	void StopScroll () {
		scrollSpeed = 0; // or find a way to stop the Update
	}
}

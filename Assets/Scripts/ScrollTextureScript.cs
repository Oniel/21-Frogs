using UnityEngine;
using System.Collections;

public class ScrollTextureScript : MonoBehaviour {

	public float scrollSpeed = 0;

	// moves texturized background
	// this only works for Texture based backgrounds; wrap mode must be Repeat
	void Update () {
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (Time.time * scrollSpeed, 0f);
	}

	void StopScroll () {
		scrollSpeed = 0;
	}
}

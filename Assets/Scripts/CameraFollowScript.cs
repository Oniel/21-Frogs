using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {

	public Transform focusedObject;
	public static int horizontalOffset = 6; // these might change later on?
	public static int verticalOffset = 2;

	// defined in the inspector, these help to identify the camera's bounds
	public GameObject leftDestroyer;
	public GameObject rightDestroyer;
	public GameObject topDestroyer;
	public GameObject bottomDestroyer;

	void Start () {
		//Update ();
	}

	// update the game camera's position (attempt 2)
	void Update() {
		// Cancel Application
		if (Input.GetKey("escape"))
			Application.Quit();


		float widthOffset = 6.0f;
		float heightOffset = 6.0f;
		float leftBoundary = leftDestroyer.transform.position.x + widthOffset;
		float rightBoundary = rightDestroyer.transform.position.x - widthOffset;
		float bottomBoundary = bottomDestroyer.transform.position.y + heightOffset;
		float topBoundary = topDestroyer.transform.position.y - heightOffset;

		float newCamPosX = transform.position.x;
		float newCamPosY = transform.position.y;

		if (focusedObject.position.x <= leftBoundary || focusedObject.position.x >= rightBoundary) {
			newCamPosX = transform.position.x;
		} else {
			newCamPosX = focusedObject.position.x;
		}

		if (focusedObject.position.y <= bottomBoundary || focusedObject.position.y >= topBoundary) {
			newCamPosY = transform.position.y;
		} else {
			newCamPosY = focusedObject.position.y;
		}

		transform.position = new Vector3 (newCamPosX, newCamPosY, -10);
		//That was way easier lolz...
	}

	/*
	// Update the Camera's position
	// the camera will follow the focused object (player) and stop whena  boundary is touched
	void FixedUpdate () {
		float camXAxis = transform.position.x;
		float camYAxis = transform.position.y;
		float camXAxisHalf = Mathf.Abs(camXAxis / 2.0f);
		float camYAxisHalf = Mathf.Abs(camYAxis / 2.0f);

		float leftBoundary = leftDestroyer.transform.position.x;
		float rightBoundary = rightDestroyer.transform.position.x;
		float topBoundary = topDestroyer.transform.position.y;
		float bottomBoundary = bottomDestroyer.transform.position.y;

		float newCamPosX;
		float newCamPosY;



		// CAMERA WORLD BOUNDARY CHECK - destroyers will be used to identify the world(camera) limits
		if ((camXAxis - camXAxisHalf) <= leftBoundary) {
			newCamPosX = leftBoundary + camXAxisHalf + 2.0f;
		} else if ((camXAxis + camXAxisHalf) >= rightBoundary) {
			newCamPosX = rightBoundary - camXAxisHalf - 2.0f;
		} else {
			// PLAYER BOUNDARY CHECK
			if (focusedObject.position.x > leftBoundary + camXAxisHalf && focusedObject.position.x < rightBoundary - camXAxisHalf) {
				newCamPosX = focusedObject.position.x;
			} else {
				newCamPosX = camXAxis;
			}
		}

		if ((camYAxis + camYAxisHalf) >= topBoundary) {
			newCamPosY = topBoundary - camYAxisHalf - 2.0f;
		} else if ((camYAxis - camYAxisHalf) <= bottomBoundary) {
			newCamPosY = bottomBoundary + camXAxisHalf + 2.0f;
		} else {
			if (focusedObject.position.y > bottomBoundary + camYAxisHalf && focusedObject.position.y < topBoundary - camYAxisHalf) {
				newCamPosY = focusedObject.position.y;
			} else {
				newCamPosY = camYAxis;
			}
		}

		Debug.Log ("camXAxis" + camXAxis + ", " + camXAxisHalf + ", " + newCamPosX);
		//Debug.Log ("camYAxis" + camYAxis);
		//Debug.Log ("camXAxisHalf" + camXAxisHalf);
		//Debug.Log ("camYAxisHalf" + camYAxisHalf);

		//Debug.Log ("leftBoundary" + leftBoundary);
		Debug.Log ("rightBoundary" + rightBoundary);
		//Debug.Log ("topBoundary" + topBoundary);
		//Debug.Log ("bottomBoundary" + bottomBoundary);

		//Debug.Log ("newCamPosX" + newCamPosX);
		//Debug.Log ("newCamPosY" + newCamPosY);

		transform.position = new Vector3 (newCamPosX, newCamPosY, -10);
	}
	*/
}

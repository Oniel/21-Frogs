﻿using UnityEngine;
using System.Collections;

public class CameraBounds : MonoBehaviour {

	void OnDrawGizmos()
	{
		float verticalHeightSeen = Camera.main.orthographicSize * 2.0f;

		Gizmos.color = Color.cyan;
		Gizmos.DrawWireCube(transform.position, new Vector3((verticalHeightSeen * Camera.main.aspect), verticalHeightSeen, 50)
		);
	}
}

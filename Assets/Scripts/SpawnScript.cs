using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject[] spawnList;
	public float spawnMinTime = 1f;
	public float spawnMaxTime = 2f;

	// Use this for initialization
	void Start () {
		Spawn();
	}

	void Spawn () {
		var spawnObj = spawnList [Random.Range (0, spawnList.Length)];
		Instantiate (spawnObj, transform.position, Quaternion.identity);
		Invoke ("Spawn", GetRandomTime());
	}

	float GetRandomTime() {
		return Random.Range (spawnMinTime, spawnMaxTime);
	}
}

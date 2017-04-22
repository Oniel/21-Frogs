using UnityEngine;
using System.Collections;

public class EnemyEdgeCheckScript : MonoBehaviour {

	EnemyScript enemyController;

	void Start () {
		enemyController = GetComponentInParent<EnemyScript> ();
	}

	// Reverse enemy object movement upon contact with a Cliff Edge
	void OnTriggerEnter2D(Collider2D collidingObject) {
		if (collidingObject.tag == "Edge") {
			enemyController.InvertMovement ();
		}
	}

	void OnTriggerStay2D(Collider2D collidingObject) {

	}

}

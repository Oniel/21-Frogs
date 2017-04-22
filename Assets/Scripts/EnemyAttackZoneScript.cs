using UnityEngine;
using System.Collections;

// handles enemy attack logic
public class EnemyAttackZoneScript : MonoBehaviour {
	EnemyScript enemyController;

	void Start () {
		enemyController = GetComponentInParent<EnemyScript> ();
	}

	void OnTriggerEnter2D (Collider2D collidingObect) {
		if (collidingObect.tag == "Player") {
			enemyController.RemoveForce ();
		}
	}
}

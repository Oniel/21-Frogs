using UnityEngine;
using System.Collections;

// destroys game objects
public class DestroyerScript : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D triggeredObject) {

		// handle player
		if (triggeredObject.tag == "Player") {
			PlayerHealth playerHealth = triggeredObject.GetComponent<PlayerHealth> ();
			playerHealth.AddDamage (playerHealth.playerMaxHealth);
			//handle all other objects
		} else if (triggeredObject.gameObject.transform.parent) {
			Destroy(triggeredObject.gameObject.transform.parent.gameObject);
		} else {
			Destroy(triggeredObject.gameObject);
		}
	}
}

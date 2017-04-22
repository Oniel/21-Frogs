using UnityEngine;
using System.Collections;

public class HealthItemScript : MonoBehaviour {

	public float healthAmount;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter2D(Collider2D collidingObject) {
		if (collidingObject.tag == "Player") {
			PlayerHealth playerHealth = collidingObject.gameObject.GetComponent<PlayerHealth> ();
			playerHealth.AddHealth (healthAmount);
		}
		// Instantiate PS Effectsqw
		Destroy (gameObject);
		//Instantiate (gameObject, transform.position, transform.rotation);
	}
}

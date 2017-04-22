using UnityEngine;
using System.Collections;

public class ProjectileHit : MonoBehaviour {

	public float projectileDamage;
	public GameObject projectileExplosionPS;

	ProjectileScript parentProjectileScript;

	void Awake () {
		parentProjectileScript = GetComponentInParent<ProjectileScript> (); // get parent script

	}

	void OnTriggerEnter2D(Collider2D collidingObject) {
		HandleObjectInteraction (collidingObject);
	}

	void OnTriggerStay2D(Collider2D collidingObject) {
		HandleObjectInteraction (collidingObject);
	}

	void HandleObjectInteraction (Collider2D collidingObject) {
		if (collidingObject.gameObject.layer == LayerMask.NameToLayer ("Shootable")) {
			// stop projectile, show PS, & Destroy
			parentProjectileScript.RemoveForce ();
			Instantiate (projectileExplosionPS, transform.position, transform.rotation);
			Destroy (gameObject);

			//
			if (collidingObject.tag == "Enemy") {
				EnemyHealth enemy = collidingObject.gameObject.GetComponent<EnemyHealth> (); // get the enemy's health script
				enemy.AddDamage(projectileDamage);
			}
		}
	}

}

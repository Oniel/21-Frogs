using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {

	public float projectileSpeed;
	public float aliveTime;

	Rigidbody2D projectileRB;

	// Use this for initialization
	void Start () {
		projectileRB = GetComponent<Rigidbody2D> ();
		if (transform.localRotation.z > 0) {
			projectileRB.AddForce (new Vector2 (-1, 0) * projectileSpeed, ForceMode2D.Impulse);
		} else {
			projectileRB.AddForce (new Vector2 (1, 0) * projectileSpeed, ForceMode2D.Impulse);
		}
	}
	
	// Update is called once per frame
	void Awake () {
		Destroy (gameObject, aliveTime);
	}

	public void RemoveForce() {
		projectileRB.velocity = new Vector2 (0, 0);
	}
}

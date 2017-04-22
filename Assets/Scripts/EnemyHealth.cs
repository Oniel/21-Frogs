using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	public float enemyMaxHealth; // get value for each enemy type
	public GameObject enemyDeathPSEffect;
	public Slider enemyHealthSlider;

	Animator enemyAnim;
	EnemyScript enemyScript;
	float currentHealth;

	// Use this for initialization 
	void Start () {
		enemyAnim = GetComponent<Animator> ();
		enemyScript = GetComponent<EnemyScript> ();


		currentHealth = enemyMaxHealth;
		enemyHealthSlider.maxValue = enemyMaxHealth;
		enemyHealthSlider.value = currentHealth;
	}

	public void AddDamage(float damage) {
		Debug.Log ("addDagmge " + damage);
		enemyHealthSlider.gameObject.SetActive(true);
		currentHealth = currentHealth - damage;
		enemyHealthSlider.value = currentHealth;
		if (currentHealth <= 0) {
			KillEnemy ();
		}
	}

	void KillEnemy () {
		if (enemyScript.enemyType == "FLYING" || enemyScript.enemyType == "CRAWLER") {
			enemyScript.RemoveForce ();

		}

		enemyAnim.SetBool ("isDead", true); // TODO this animation is not working, not sure why
		Destroy (gameObject, 0.5f);
		Instantiate (enemyDeathPSEffect, transform.position, transform.rotation);

		enemyScript.UpdateScore ();
	}
		
}

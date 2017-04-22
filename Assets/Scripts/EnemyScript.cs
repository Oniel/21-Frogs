using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class EnemyScript : MonoBehaviour {


	public float damage;
	public float damageRate;
	public float pushBackForce;
	public string enemyType; // FROG, ENVIRONMENT, FLYING
	public float enemySpeed;
	public Text gameOverWinner;

	Rigidbody2D enemyRB;

	float nextDamage;
	Text scoreText;
	// Use this for initialization
	void Start () {
		enemyRB = GetComponent<Rigidbody2D> ();

		nextDamage = 0f;
		scoreText = GameObject.Find ("DeadFrogUICount").GetComponent<Text>();
		scoreText.text = 0.ToString ();

		// AI Enemy Movement
		if (enemyType == "FLYING" || enemyType == "CRAWLER") {
			enemyRB.AddForce (new Vector2 (-1, 0) * enemySpeed, ForceMode2D.Impulse); // enemy moves to the left initially
		}
	}

	// invert character movement and facing direction
	public void InvertMovement() {
		Vector3 scaling = transform.localScale;
		scaling.x *= -1;
		transform.localScale = scaling;
	
		RemoveForce ();
		if (transform.localScale.x > 0) {
			enemyRB.AddForce (new Vector2 (-1, 0) * enemySpeed, ForceMode2D.Impulse);
		} else {
			enemyRB.AddForce (new Vector2 (1, 0) * enemySpeed, ForceMode2D.Impulse);
		}
	}

	public void RemoveForce() {
		enemyRB.velocity = new Vector2 (0, 0);
	}

	void OnTriggerStay2D(Collider2D collidingObject) {
			if (collidingObject.tag == "Player" && nextDamage < Time.time) {
				PlayerHealth playerHealth = collidingObject.gameObject.GetComponent<PlayerHealth> ();
				playerHealth.AddDamage(damage);
				nextDamage = Time.time + damageRate;

				PushBack(collidingObject.transform);
			}
	}

	void PushBack(Transform collidingObject) {
		Vector2 pushDirection = new Vector2 (0, (collidingObject.position.y - transform.position.y)).normalized; // push left or right
		pushDirection *= pushBackForce;
		Rigidbody2D collidingObjectRB = collidingObject.GetComponent<Rigidbody2D> ();

		//stop any current movement & apply psudh direction
		collidingObjectRB.velocity = Vector2.zero;
		collidingObjectRB.AddForce(pushDirection, ForceMode2D.Impulse);

	}

	// Update the HUD Score
	public void UpdateScore () {
		//var script = GameObject.Find ("DeadFrogUICount")
		if (enemyType == "FROG") {
			int newScore = int.Parse (scoreText.text) + 1;
			scoreText.text = (newScore).ToString();

			if (newScore == 21) {
				Animator gameOverAnim = gameOverWinner.GetComponent<Animator> ();
				gameOverAnim.SetTrigger ("gameOverWinner");
			}
		}
	}
}

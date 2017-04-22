using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	// public inspector variables
	public float maxSpeed;
	public float jumpPower;
	public float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	public Transform groundChecker;
	public Transform projectileGenerator;
	public GameObject projectile;
	bool hasDoubleJumped = false;

	// privates
	Rigidbody2D playerRB;
	Animator 	playerAnim;
	bool rightFacing = true;
	bool isGrounded = false;
	float fireRate = 0.5f; // Change this to be based on collectables
	float nextFire = 0f;
	float nextJump;

	// Use this for initialization
	void Start () {
		playerRB = GetComponent<Rigidbody2D> ();
		playerAnim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		// Handle JUMP request
		if (Input.GetAxis("Jump") > 0 && (isGrounded || !hasDoubleJumped)) {
			if (isGrounded) {
				isGrounded = false;
				playerAnim.SetBool ("isPlayerGrounded", false);
				playerRB.AddForce(new Vector2(0, jumpPower));
				nextJump = Time.time + 0.2f;
			} else if (!hasDoubleJumped && nextJump < Time.time) {
				//Debug.Log ("doubleJHuno");
				hasDoubleJumped = true;
				playerRB.AddForce(new Vector2(0, jumpPower));
				//playerRB.velocity = new Vector2 (0, playerRB.velocity.y);
			}
		}

		// Handle FIRE1 request
		if (Input.GetAxisRaw ("Fire1") > 0) 
			ThrowProjectile ();


		// Handle FIRE2 request

		// Handle FIRE3 request
	}

	// Do Physics based updates here
	void FixedUpdate () {
		//vertical movement checks
		isGrounded = Physics2D.OverlapCircle(groundChecker.position, groundCheckRadius, groundLayer); // check if groundLayer has come incontact with groundChecker
		playerAnim.SetBool("isPlayerGrounded", isGrounded);
		playerAnim.SetFloat ("playerVerticalSpeed", playerRB.velocity.y);

		// double jump 
		if (isGrounded)
			hasDoubleJumped = false;
		
		// horizontal movement checks
		float movement = Input.GetAxis ("Horizontal"); // left - negative, right - positive

		playerAnim.SetFloat ("playerHorizontalSpeed", Mathf.Abs (movement));
		playerRB.velocity = new Vector2 (movement * maxSpeed, playerRB.velocity.y);

		// character flip check
		if (movement > 0 && !rightFacing) {
			Flip ();
		} else if (movement < 0 && rightFacing){
			Flip ();
		}
	}

	void Flip () {
		Vector3 scaling = transform.localScale;
		scaling.x *= -1;
		transform.localScale = scaling;

		rightFacing = !rightFacing;
	}

	void ThrowProjectile () {
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			if (rightFacing) {
				Instantiate(projectile, projectileGenerator.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
			} else {
				Instantiate(projectile, projectileGenerator.position, Quaternion.Euler (new Vector3 (0, 0, 180f)));
			}
		}
	}


}

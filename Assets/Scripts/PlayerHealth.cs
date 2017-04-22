using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// this can be merged with enemy health with some overrides...
public class PlayerHealth : MonoBehaviour {

	public float playerMaxHealth;
	public GameObject deathPSEffect;
	public Slider healthSlider;
	public Image damageScreen;
	public Text gameOverLoser;
	public GameRestart restartManager;
	float currentHealth;
	bool isDamaged = false;
	PlayerScript playerScript;
	Color damagedColor = new Color(0f, 0f, 0f, 0.5f);
	float smoothColor = 5f;
	public AudioClip[] hurtAudioClips; // add array of clips later on
	//public AudioClip death 
	AudioSource playerAS;

	// Use this for initialization
	void Start () {
		currentHealth = playerMaxHealth;

		healthSlider.maxValue = playerMaxHealth;
		healthSlider.value = currentHealth;

		playerAS = GetComponent<AudioSource> ();
	}

	void Update () {
		if (isDamaged) {
			damageScreen.color = damagedColor;
		} else {
			damageScreen.color = Color.Lerp (damageScreen.color, Color.clear, smoothColor * Time.deltaTime);
		}
		isDamaged = false;
	}

	public void AddDamage(float damage) {
		if (damage <= 0)
			return; // not necassary
		
		currentHealth = currentHealth - damage;
		healthSlider.value = currentHealth;
		isDamaged = true;

		playerAS.clip = hurtAudioClips[Random.Range(0, hurtAudioClips.Length)];
		playerAS.Play ();

		if (currentHealth <= 0) {
			KillPlayer ();
		}
	}

	public void AddHealth(float additionalHealth) {
		currentHealth += additionalHealth;
		if (currentHealth > playerMaxHealth)
			currentHealth = playerMaxHealth;
		healthSlider.value = currentHealth;
	}

	void KillPlayer () {
		Instantiate (deathPSEffect, transform.position, transform.rotation);
		// AudioSource.PlayClipAtPoint (playerDeathSound, tranform.position); // Add death sound upon player death

		Destroy (gameObject);
		Animator gameOverAnim = gameOverLoser.GetComponent<Animator> ();
		gameOverAnim.SetTrigger ("gameOverLoser");
		restartManager.gameRestart ();
	}
}

using UnityEngine;
using System.Collections;

public class healthRestore : MonoBehaviour {

	AudioSource restore;
	PlayerHealth playerHealth;
	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		restore = GetComponent <AudioSource> ();
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			playerHealth.currentHealth = playerHealth.startingHealth;
			playerHealth.healthSlider.value = playerHealth.currentHealth;
			restore.Play();
		}
	}

}

using UnityEngine;
using System.Collections;

public class lavaScript : MonoBehaviour {

	GameObject player;
	PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
	}
	
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			if(playerHealth.currentHealth > 0)
			{
				playerHealth.TakeDamage (playerHealth.currentHealth);
			}
		}
	}
}

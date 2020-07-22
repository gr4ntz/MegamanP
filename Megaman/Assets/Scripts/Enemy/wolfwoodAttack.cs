using UnityEngine;
using System.Collections;

public class wolfwoodAttack : MonoBehaviour {


	public int attackDamage = 10;

	GameObject player;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;


	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		enemyHealth = GetComponent<EnemyHealth>();
	}


	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			if(playerHealth.currentHealth > 0)
			{
				playerHealth.TakeDamage (attackDamage);
			}
		}
	}
}

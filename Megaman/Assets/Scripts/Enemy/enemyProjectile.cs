using UnityEngine;
using System.Collections;

public class enemyProjectile : MonoBehaviour {
	public int attackDamage = 20;

	GameObject player;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;
	float timer;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		enemyHealth = GetComponent<EnemyHealth>();
		timer = 0f;
	}

	void Update()
	{
		timer += Time.deltaTime;
		if(timer >= 5f)
		{
			Destroy (gameObject, 2f);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			if(playerHealth.currentHealth > 0)
			{
				playerHealth.TakeDamage (attackDamage);


			}
			Destroy (gameObject, 2f);
		}
	}
}

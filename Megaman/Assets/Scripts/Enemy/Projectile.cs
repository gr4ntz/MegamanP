using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public int attackDamage = 20;

	public playerHealth2 playerHealth2;

	public GameObject player;

	float timer = 0f;

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			if(playerHealth2.currentHealth > 0)
			{
				playerHealth2.TakeDamage (attackDamage);


			}
		}
	}

	void Update()
	{
		timer += Time.deltaTime;
		transform.localScale -= new Vector3(0.1f, 0, 0.1f)*Time.deltaTime;
		if(timer >= 5f)
		{
			Destroy(gameObject);
		}
	}
}

using UnityEngine;
using System.Collections;

public class beeAttack : MonoBehaviour {

	public Rigidbody projectile;
	public Transform gunEnd;
	public Transform player;
	public int damagePerShot = 20;
	public float timeBetweenBullets = 5f;
	public float projectileForce = 500f;
	float timer;
	EnemyHealth enemyHealth;

	// Use this for initialization
	void Start () {
		timer = 0f;
		enemyHealth = GetComponent<EnemyHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer >= timeBetweenBullets && Time.timeScale != 0 && enemyHealth.currentHealth > 0)
		{
			timer = 0f;
			Rigidbody cloneRB = Instantiate(projectile,transform.position+(player.position - transform.position).normalized,Quaternion.LookRotation(player.position - transform.position)) as Rigidbody;
			cloneRB.AddForce(gunEnd.transform.forward*projectileForce);
		}
	}
}

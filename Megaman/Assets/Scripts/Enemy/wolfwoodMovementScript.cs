using UnityEngine;
using System.Collections;

public class wolfwoodMovementScript : MonoBehaviour {

	Transform Tplayer;

	float iddleRandom;
	GameObject player;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;
	UnityEngine.AI.NavMeshAgent nav;
	Animator anim;
	public bool playerInRange = false;


	void Awake ()
	{
		playerHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent <PlayerHealth> ();
		Tplayer = GameObject.FindGameObjectWithTag ("Player").transform;
		player = GameObject.FindGameObjectWithTag ("Player");
		enemyHealth = GetComponent <EnemyHealth> ();
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
		anim = GetComponent <Animator> ();
	}


	void Update ()
	{
		if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && playerInRange == false)
		{
			anim.SetBool("move",true);
			anim.SetBool("attack",false);
			nav.enabled = true;
			nav.SetDestination (Tplayer.position);
			transform.LookAt(Tplayer);
		}
		else if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && playerInRange == true)
		{
			anim.SetBool("move",false);
			anim.SetBool("attack",true);
			nav.enabled = false;
		}
		else if(playerHealth.currentHealth <= 0)
		{
			anim.SetBool("move",false);
			anim.SetBool("attack",false);
			nav.enabled = false;
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = true;
		}
	}


	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = false;
		}
	}
		
}

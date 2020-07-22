using UnityEngine;
using System.Collections;

public class beeMovement : MonoBehaviour {

	public Transform navPoint1;
	public Transform navPoint2;
	public Transform navPoint3;
	public Transform player;

	string beeState;
	float iddleRandom;
	Transform navPoint;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;
	UnityEngine.AI.NavMeshAgent nav;


	void Awake ()
	{
		playerHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent <PlayerHealth> ();
		enemyHealth = GetComponent <EnemyHealth> ();
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
		beeState = "iddle";
	}


	void Update ()
	{
		transform.LookAt(player);
		if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
		{
			if(beeState == "iddle")
			{
				Iddle();
			}
			else if(beeState == "move")
			{
				Move();
			}
		}
		else
		{
			nav.enabled = false;
		}
	}

	void Iddle()
	{
		iddleRandom = Random.Range(1f, 1000f);
		if(iddleRandom<=10f)
		{
			navPoint = navPoint1;
			beeState = "move";
		}
		else if(iddleRandom<=20)
		{
			navPoint = navPoint2;
			beeState = "move";
		}
		else if(iddleRandom<=30)
		{
			navPoint = navPoint3;
			beeState = "move";
		}
	}

	void Move()
	{
		nav.SetDestination (navPoint.position);
		if (!nav.pathPending)
		{
			if (nav.remainingDistance <= nav.stoppingDistance)
			{
				if (!nav.hasPath || nav.velocity.sqrMagnitude == 0f)
				{
					beeState = "iddle";
				}
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class activateEnemy : MonoBehaviour {
	public GameObject enemy;


	GameObject player;
	playerEnterRoom per;

	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		per = GetComponentInParent<playerEnterRoom>(); 
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			enemy.SetActive(true);
			per.enemyLeft++;
		}
	}
}

using UnityEngine;
using System.Collections;

public class sealDoor : MonoBehaviour {
	public GameObject door;


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
			door.GetComponent<Animation>().Play("close");
		}
	}

	void Update()
	{
		if(per.enemyLeft == 0)
		{
			door.GetComponent<SphereCollider>().enabled = true;
		}
		else
		{
			door.GetComponent<SphereCollider>().enabled = false;
		}
	}
}

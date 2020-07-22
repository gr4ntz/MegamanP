using UnityEngine;
using System.Collections;

public class playerEnterRoom : MonoBehaviour {

	public AudioSource bgmusic;
	public AudioClip normalmusic;
	public AudioClip battlemusic;
	public int enemyLeft;

	GameObject player;

	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		enemyLeft = 0;
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			bgmusic.clip=battlemusic;
			bgmusic.Play();
			this.GetComponent<BoxCollider>().enabled = false;
			this.GetComponent<playerEnterRoom>().enabled = true;
		}
	}

	void Update()
	{
		if(enemyLeft == 0)
		{
			bgmusic.clip=normalmusic;
			bgmusic.Play();
			this.GetComponent<playerEnterRoom>().enabled = false;
		}
	}
}

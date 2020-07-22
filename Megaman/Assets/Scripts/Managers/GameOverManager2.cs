using UnityEngine;
using System.Collections;

public class GameOverManager2 : MonoBehaviour {

	public playerHealth2 playerHealth;


	Animator anim;


	void Awake()
	{
		anim = GetComponent<Animator>();
	}


	void Update()
	{
		if (playerHealth.currentHealth <= 0)
		{
			anim.SetTrigger("GameOver");
		}
	}
}

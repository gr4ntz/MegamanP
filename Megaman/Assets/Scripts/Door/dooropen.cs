using UnityEngine;
using System.Collections;

public class dooropen : MonoBehaviour {

	Animation anim;
	GameObject player;

	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent <Animation> ();
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			anim.Play("open");
			//this.GetComponent<SphereCollider>().enabled = false;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == player)
		{
			anim.Play("close");
			//this.GetComponent<SphereCollider>().enabled = false;
		}
	}
}

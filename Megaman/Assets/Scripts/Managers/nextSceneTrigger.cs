using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class nextSceneTrigger : MonoBehaviour {

	public int scene;
	public GameObject per;

	GameObject player;

	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			SceneManager.LoadScene(scene);
		}
	}

	void Update()
	{
		if(per.GetComponent<playerEnterRoom>().enemyLeft == 0)
		{
			GetComponent<BoxCollider>().enabled = true;
		}
		else
		{
			GetComponent<BoxCollider>().enabled = false;
		}
	}
}

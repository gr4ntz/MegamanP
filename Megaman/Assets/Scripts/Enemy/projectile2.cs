using UnityEngine;
using System.Collections;

public class projectile2 : MonoBehaviour {

	public int attackDamage = 20;

	public playerHealth2 playerHealth2;

	public GameObject player;

	public float speed = 500f;

	public GameObject targetGO;

	public Transform target;

	public GameObject explosion;

	Rigidbody RB;

	float timer=0f;

	bool hit = false;
	bool forward = true;
	MeshRenderer MR;

	void Awake()
	{
		RB = GetComponent<Rigidbody>();
		MR = GetComponent<MeshRenderer>();
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			if(playerHealth2.currentHealth > 0 && hit == false)
			{
				playerHealth2.TakeDamage (attackDamage);
				hit = true;
				MR.enabled = false;
				explosion.SetActive(true);
				Destroy (gameObject, 2f);
			}
		}
		if(other.gameObject == targetGO)
		{
			forward = false;
		}
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		RB.AddForce(transform.forward*speed);
		if(forward == true)
		{
			transform.LookAt(target);
		}
		if(timer >= 5f)
		{
			Destroy(gameObject);
		}
	}
}

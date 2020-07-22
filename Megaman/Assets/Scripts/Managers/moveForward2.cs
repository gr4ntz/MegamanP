using UnityEngine;
using System.Collections;

public class moveForward2 : MonoBehaviour {

	//Rigidbody RB;
	public float speed = 500f;
	public Transform target;

	/*void Start()
	{
		RB = GetComponent<Rigidbody>();
	}*/

	// Update is called once per frame
	void Update () {
		transform.LookAt(target);
		//RB.AddForce(transform.forward*speed);
		transform.Translate(Vector3.forward*speed*Time.deltaTime);
	}
}

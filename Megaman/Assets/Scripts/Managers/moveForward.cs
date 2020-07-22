using UnityEngine;
using System.Collections;

public class moveForward : MonoBehaviour {

	public Rigidbody RB;
	public Transform TRB;
	public float speed = 500f;
	public Transform target;
	
	// Update is called once per frame
	void Update () {
		TRB.transform.LookAt(target);
		RB.AddForce(transform.forward*speed);
	}
}

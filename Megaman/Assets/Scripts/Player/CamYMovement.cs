/*
using UnityEngine;
using System.Collections;

public class CamYMovement : MonoBehaviour {
	
	public float m_TurnSpeed = 180f;  
	private string m_TurnAxisName;
	private float m_TurnInputValue; 
	private float turn;

	// Use this for initialization
	void Start () {
		m_TurnAxisName = "Cam Y";
	}
	
	// Update is called once per frame
	void Update () {
		m_TurnInputValue = Input.GetAxis(m_TurnAxisName);
	}

	private void FixedUpdate ()
	{
		Turn();
	}

	private void Turn ()
	{
		
		turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;
			
		Quaternion turnRotation = Quaternion.Euler(-turn, 0f, 0f);

		transform.rotation = transform.rotation * turnRotation;
		
		
	}

}
*/
using UnityEngine;
using System.Collections;

public class CamYMovement : MonoBehaviour {
		
	public float minY = -45.0f;
	public float maxY = 45.0f;

	public float sensY = 100.0f;
	
	float rotationY = 0.0f;
	float rotationX = 0.0f;

	void Update () {
					
			rotationY += Input.GetAxis ("Cam Y") * sensY * Time.deltaTime;
			rotationY = Mathf.Clamp (rotationY, minY, maxY);
			transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);
		
	}
}

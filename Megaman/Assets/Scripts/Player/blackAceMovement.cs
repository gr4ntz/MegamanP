using UnityEngine;
using System.Collections;

public class blackAceMovement : MonoBehaviour {

	public Rigidbody m_Rigidbody;
	public float m_Speed = 12f;  

	private string m_ForwardMovementAxisName;     
	private string m_SideMovementAxisName;             
	private float m_ForwardMovementInputValue;    
	private float m_SideMovementInputValue;    

	// Use this for initialization
	void Start () {
		m_ForwardMovementInputValue = 0f;
		m_SideMovementInputValue = 0f;
		m_ForwardMovementAxisName = "Vertical";
		m_SideMovementAxisName = "Horizontal";
	}
	
	// Update is called once per frame
	void Update () {
		m_ForwardMovementInputValue = Input.GetAxis(m_ForwardMovementAxisName);
		m_SideMovementInputValue = Input.GetAxis(m_SideMovementAxisName);
	}

	private void FixedUpdate()
	{
		Move();
	}

	private void Move()
	{
		Vector3 ForwardMovement = transform.up * m_ForwardMovementInputValue * m_Speed * Time.deltaTime;
		m_Rigidbody.MovePosition(m_Rigidbody.position + ForwardMovement);
		Vector3 SideMovement = transform.right* 2f * m_SideMovementInputValue * m_Speed * Time.deltaTime;
		m_Rigidbody.MovePosition(m_Rigidbody.position + SideMovement);
	}
}

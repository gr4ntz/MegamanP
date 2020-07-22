using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{  
	public float m_Speed = 12f;           
	public float m_TurnSpeed = 180f;       
	public float timeBetweenDash = 1f;
	public AudioClip rollClip;

	private float m_InitialSpeed;
	private string m_ForwardMovementAxisName;     
	private string m_SideMovementAxisName;
	private string m_TurnAxisName;         
	private Rigidbody m_Rigidbody;         
	private float m_ForwardMovementInputValue;    
	private float m_SideMovementInputValue;    
	private float m_TurnInputValue;        
	private Animator animator;
	private float timer;
	private float rollT;
	PlayerShooting playerShooting;
	AudioSource playerAudio;
	PlayerHealth playerHealth;

	private void Awake()
	{
		playerAudio = GetComponent <AudioSource> ();
		m_Rigidbody = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
		playerShooting = GetComponentInChildren <PlayerShooting> ();
		playerHealth = GetComponentInChildren <PlayerHealth> ();
		m_InitialSpeed = m_Speed;
	}


	private void OnEnable ()
	{
		m_Rigidbody.isKinematic = false;
		m_ForwardMovementInputValue = 0f;
		m_SideMovementInputValue = 0f;
		m_TurnInputValue = 0f;

	}


	private void OnDisable ()
	{
		m_Rigidbody.isKinematic = true;
	}


	private void Start()
	{
		m_ForwardMovementAxisName = "Vertical";
		m_SideMovementAxisName = "Horizontal";
		m_TurnAxisName = "Cam X";
	}


	private void Update()
	{
		m_ForwardMovementInputValue = Input.GetAxis(m_ForwardMovementAxisName);
		m_SideMovementInputValue = Input.GetAxis(m_SideMovementAxisName);
		m_TurnInputValue = Input.GetAxis(m_TurnAxisName);
		timer += Time.deltaTime;
		if(Input.GetButtonDown("Dash") && timer >= timeBetweenDash && Time.timeScale != 0 && (m_ForwardMovementInputValue != 0f || m_SideMovementInputValue !=0f))
		{
			animator.SetBool("Dash",true);
			m_Speed = m_InitialSpeed * 5;
			timer = 0f;
			playerShooting.enabled = false;
			playerAudio.clip = rollClip;
			playerAudio.Play ();
		}
	}

	private void FixedUpdate()
	{
		if(animator.GetBool("Dash") == true)
		{
			Roll();
		}
		else
		{
			Move();
		}

		Turn();
	}


	private void Move()
	{
		Vector3 ForwardMovement = transform.forward * m_ForwardMovementInputValue * m_Speed * Time.deltaTime;
		m_Rigidbody.MovePosition(m_Rigidbody.position + ForwardMovement);
		Vector3 SideMovement = transform.right* 2f * m_SideMovementInputValue * m_Speed * Time.deltaTime;
		m_Rigidbody.MovePosition(m_Rigidbody.position + SideMovement);
	}

	private void Roll()
	{
		rollT += Time.deltaTime;
		playerHealth.invincible = true;
		if(rollT < 0.8f && rollT > 0.2f)
		{
		Vector3 ForwardMovement = transform.forward * m_ForwardMovementInputValue * m_Speed * Time.deltaTime;
		m_Rigidbody.MovePosition(m_Rigidbody.position + ForwardMovement);
		Vector3 SideMovement = transform.right* 2f * m_SideMovementInputValue * m_Speed * Time.deltaTime;
		m_Rigidbody.MovePosition(m_Rigidbody.position + SideMovement);
		}

	}

	private void Turn()
	{
		float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

		Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

		m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);

		animator.SetFloat("cam X",m_TurnInputValue);
	}
		
	public void RollOff()
	{
		animator.SetBool("Dash",false);
		m_Speed = m_InitialSpeed;
		rollT = 0f;
		playerShooting.enabled = true;
		playerHealth.invincible = false;
	}
}
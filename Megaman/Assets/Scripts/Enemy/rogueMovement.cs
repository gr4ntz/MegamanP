using UnityEngine;
using System.Collections;

public class rogueMovement : MonoBehaviour {

	Transform Tplayer;
	float iddleRandom;
	GameObject player;
	PlayerHealth playerHealth;
	EnemyHealth enemyHealth;
	Animator anim;
	public string state;
	UnityEngine.AI.NavMeshAgent nav;
	float timer;
	bool trigger;
	bool powerEffectBool;
	public float projectileForce = 500f;
	public Transform gunEnd;
	public Rigidbody projectile;
	public ParticleSystem dashEffect;
	public ParticleSystem powerEffect;
	public AudioClip dashAudio;
	public AudioClip slashAudio;
	public AudioClip powerUpAudio;
	public AudioClip blastAudio;
	public AudioClip talk1;
	public AudioClip talk2;
	public AudioClip talk3;
	public AudioSource effectAudio;
	public AudioSource talkAudio;
	private bool right;
	private Rigidbody m_Rigidbody;  

	void Awake ()
	{
		playerHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent <PlayerHealth> ();
		Tplayer = GameObject.FindGameObjectWithTag ("Player").transform;
		player = GameObject.FindGameObjectWithTag ("Player");
		enemyHealth = GetComponent <EnemyHealth> ();
		anim = GetComponent <Animator> ();
		m_Rigidbody = GetComponent<Rigidbody>();
		state = "iddle";
		nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
	}


	void Update ()
	{
		
		if(state == "iddle")
		{
			nav.enabled = false;
			//transform.LookAt(Tplayer);
			anim.SetBool("dash",false);
			anim.SetBool("iddle",true);
			anim.SetBool("attack1",false);
			anim.SetBool("attack2",false);
			trigger = false;
			powerEffectBool = false;
			Iddle();
		}
		else if(state == "dash")
		{
			transform.LookAt(Tplayer);
			anim.SetBool("dash",true);
			anim.SetBool("iddle",false);
			anim.SetBool("attack1",false);
			anim.SetBool("attack2",false);
			trigger = true;
			powerEffectBool = false;
			Dash();
		}
		else if(state == "attack2")
		{
			nav.enabled = false;
			transform.LookAt(Tplayer);
			anim.SetBool("dash",false);
			anim.SetBool("iddle",false);
			anim.SetBool("attack1",false);
			anim.SetBool("attack2",true);
			if(!powerEffectBool){
				effectAudio.clip = powerUpAudio;
				effectAudio.Play();
				talkAudio.clip = talk2;
				talkAudio.Play();
				powerEffect.Play();
				powerEffectBool = true;
			} 
			trigger = false;
		}
	}

	void Iddle()
	{
		timer += Time.deltaTime;

		if(timer > 3f)
		{
			iddleRandom = Random.Range(1f, 10f);
			if(iddleRandom > 5f)
			{
				state = "dash";
			}
			else
			{
				state = "attack2";
			}
			timer = 0f;
		}
	}

	void Dash()
	{
		timer += Time.deltaTime;
		nav.enabled = true;
		nav.SetDestination (Tplayer.position);
		if(timer > 1f)
		{
			if(right == true)
			{
				this.transform.localPosition += transform.right * 50f * Time.deltaTime;
				dashEffect.Play();
				effectAudio.clip = dashAudio;
				effectAudio.Play();
				timer = 0f;
				right = false;
			}
			else
			{
				this.transform.localPosition += transform.right * -50f * Time.deltaTime;
				effectAudio.clip = dashAudio;
				effectAudio.Play();
				timer = 0f;
				right = true;
			}
		}
	}

	public void Attack2()
	{
		Rigidbody cloneRB = Instantiate(projectile,transform.position+(Tplayer.position - transform.position).normalized,Quaternion.LookRotation(Tplayer.position - transform.position)) as Rigidbody;
		cloneRB.AddForce(gunEnd.transform.forward*projectileForce);
		effectAudio.clip = blastAudio;
		effectAudio.Play();
		talkAudio.clip = talk3;
		talkAudio.Play();
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			if(trigger){
				state = "attack1";
				anim.SetBool("dash",false);
				anim.SetBool("iddle",false);
				anim.SetBool("attack1",true);
				anim.SetBool("attack2",false);
				trigger = false;
				//effectAudio.clip = slashAudio;
				//effectAudio.Play();
				talkAudio.clip = talk1;
				talkAudio.Play();
			}

		}
	}

	public void SetIddle ()
	{
		state = "iddle";
	}
		
}

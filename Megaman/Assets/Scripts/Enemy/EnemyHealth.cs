using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;
	public GameObject explosion;


    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        currentHealth = startingHealth;
    }


    void Update ()
    {
        if(isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(isDead)
            return;

        enemyAudio.Play ();

        currentHealth -= amount;
            
        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if(currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger ("Dead");

       
    }


    public void StartSinking ()
    {
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
		enemyAudio.clip = deathClip;
		enemyAudio.Play ();
        isSinking = true;
		EnemyLeft.enemyLeft-=1;
        //ScoreManager.score += scoreValue;
        Destroy (gameObject, 2f);
    }

	public void StartSinking2 ()
	{
		GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
		GetComponent <Rigidbody> ().isKinematic = true;
		enemyAudio.clip = deathClip;
		enemyAudio.Play ();
		explosion.SetActive(true);
		isSinking = true;
		GetComponentInParent<playerEnterRoom>().enemyLeft-=1;
		//ScoreManager.score += scoreValue;
		Destroy (gameObject, 2f);
	}

	public void StartSinking3 ()
	{
		GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
		enemyAudio.clip = deathClip;
		enemyAudio.Play ();
		isSinking = true;
		explosion.SetActive(true);
		GetComponentInParent<playerEnterRoom>().enemyLeft-=1;
		Destroy (gameObject, 1f);
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
	public AudioClip hurtClip;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	public int scene;


    Animator anim;
    AudioSource playerAudio;
	PlayerController playerMovement;
    PlayerShooting playerShooting;
    bool isDead;
    bool damaged;
	bool restart = false;
	float timer = 0f;
	public bool invincible;

    void Awake ()
    {
        anim = GetComponent <Animator> ();
        playerAudio = GetComponent <AudioSource> ();
		playerMovement = GetComponent <PlayerController> ();
        playerShooting = GetComponentInChildren <PlayerShooting> ();
        currentHealth = startingHealth;
		invincible = false;
    }


    void Update ()
    {
        if(damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
		if(restart)
		{
			timer += Time.deltaTime;
			if(timer >= 3f){
				SceneManager.LoadScene (scene);
			}
		}
    }


    public void TakeDamage (int amount)
    {
		if(invincible == false){
		damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

		playerAudio.clip = hurtClip;

        playerAudio.Play ();

		if(currentHealth <= 0 && !isDead)
        {
            Death ();
        }
		else
		{
		anim.SetBool("Hit",true);
		}
		}
    }

	public void AfterHit ()
	{
		anim.SetBool("Hit",false);
	}


    void Death ()
    {
        isDead = true;

        playerShooting.DisableEffects ();

        anim.SetTrigger ("Die");

        playerAudio.clip = deathClip;
        playerAudio.Play ();

        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }


    public void RestartLevel ()
    {
		
		restart = true;

    }

}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class playerHealth2 : MonoBehaviour {
		public int startingHealth = 100;
		public int currentHealth;
		public Slider healthSlider;
		public Image damageImage;
		public AudioClip hurtClip;
		public AudioClip deathClip;
		public float flashSpeed = 5f;
		public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
		public int scene;


		AudioSource playerAudio;
		bool isDead;
		bool damaged;
		bool restart = false;
		float timer = 0f;
		public bool invincible;

		void Awake ()
		{
			playerAudio = GetComponent <AudioSource> ();
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
			}
		}


		void Death ()
		{
			isDead = true;

			playerAudio.clip = deathClip;
			playerAudio.Play ();

			restart = true;
		}
}

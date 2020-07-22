using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bossHealthSlider : MonoBehaviour {

	Slider healthSlider;
	EnemyHealth bossHealth;
	public int scene;


	// Use this for initialization
	void Awake () {
		healthSlider = GetComponent<Slider>();
		bossHealth = GameObject.FindGameObjectWithTag ("Boss").GetComponent <EnemyHealth> ();
		healthSlider.maxValue = 5000;
	}
	
	// Update is called once per frame
	void Update () {
		healthSlider.value = bossHealth.currentHealth;
		if(healthSlider.value <= 0)
		{
			SceneManager.LoadScene (scene);
		}
	}
}

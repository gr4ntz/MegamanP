using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour {
	
	//public AudioMixerSnapshot paused;
	//public AudioMixerSnapshot unpaused;
	
	Canvas canvas;
	AudioSource BGM;

	public bool isPausing;
	
	void Start()
	{
		canvas = GetComponent<Canvas>();
		BGM = GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>();
		isPausing = false;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			canvas.enabled = !canvas.enabled;
			Pause();
		}
	}
	
	public void Pause()
	{
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
		if(BGM.isPlaying == true && isPausing == false)
		{
			BGM.Pause();
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			isPausing = true;
		}
		else
		{
			BGM.Play();
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			isPausing = false;
		}
		//Lowpass ();
		
	}
	
	/*void Lowpass()
	{
		if (Time.timeScale == 0)
		{
			paused.TransitionTo(.01f);
		}
		
		else
			
		{
			unpaused.TransitionTo(.01f);
		}
	}*/
	
	public void Quit()
	{
		#if UNITY_EDITOR 
		EditorApplication.isPlaying = false;
		#else 
		Application.Quit();
		#endif
	}
}

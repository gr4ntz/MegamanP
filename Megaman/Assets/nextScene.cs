using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour {

	public int scene;

	// Use this for initialization
	void Start () {
		SceneManager.LoadScene(scene);
	}
}

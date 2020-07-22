using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NextScene : MonoBehaviour {

	public int scene;

	public void Nextscene()
	{
		SceneManager.LoadScene(scene);
	}
}

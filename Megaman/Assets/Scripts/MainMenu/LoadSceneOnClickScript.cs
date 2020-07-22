using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadSceneOnClickScript : MonoBehaviour {


	public void LoadByIndex(int sceneIndex)
	{
		//SceneManager.LoadScene(sceneIndex);
		StartCoroutine(Loading(sceneIndex));
	}

	public IEnumerator Loading(int scene)
	{


		yield return new WaitForSeconds(3);

		AsyncOperation async = SceneManager.LoadSceneAsync(scene);

		while (!async.isDone) {
			yield return null;
		}
	}
}

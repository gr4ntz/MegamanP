using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class tutorialButton : MonoBehaviour {

	public GameObject prevButton;
	public GameObject nextButton;
	public GameObject move;
	public GameObject shoot;
	public GameObject roll;
	public GameObject qte;
	public GameObject fly;
	public GameObject loading;
	int i=0;
	public int scene;

	
	// Update is called once per frame
	void Update () {
		if(i == 0)
		{
			prevButton.SetActive(false);
			move.SetActive(true);
			shoot.SetActive(false);
		}
		else if(i == 1)
		{
			prevButton.SetActive(true);
			shoot.SetActive(true);
			roll.SetActive(false);
		}else if(i == 2)
		{
			roll.SetActive(true);
			qte.SetActive(false);
		}
		else if(i == 3)
		{
			qte.SetActive(true);
			fly.SetActive(false);
		}
		else if(i == 4)
		{
			fly.SetActive(true);
		}
		else if(i == 5)
		{
			loading.SetActive(true);
			StartCoroutine(Loading(scene));
		}
	}

	public void PrevButton()
	{
		i-=1;
	}

	public void NextButton()
	{
		i+=1;
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

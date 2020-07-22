using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyLeft : MonoBehaviour {

	public static int enemyLeft;
	public int scene;
	public int startingEnemyLeft;
	public Text kill;
	public GameObject loading;
	GameObject[] enemy;

	void Awake(){
		enemyLeft = startingEnemyLeft;
	}

	// Use this for initialization
	void Update () {
		kill.text = enemyLeft.ToString();
		if(enemyLeft <= 0){
			enemy = GameObject.FindGameObjectsWithTag("Enemy");
			for(var i=0; i<enemy.Length;i++)
			{
				Destroy(enemy[i]);
			}
			loading.SetActive(true);
			Time.timeScale = Time.timeScale == 0 ? 1 : 0;
			StartCoroutine(Loading(scene));
		}
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

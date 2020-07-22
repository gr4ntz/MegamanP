using UnityEngine;
using System.Collections;

public class QTECutscene13 : MonoBehaviour {

	public string button;
	public GameObject QTE;
	public GameObject Red;
	public GameObject buttonA;
	public GameObject buttonS;
	public GameObject buttonW;
	public GameObject buttonD;
	public GameObject buttonShift;
	public playerHealth2 playerHealth2;
	public int attackDamage = 20;
	bool invincible = false;

	float timer;


	// Use this for initialization
	void Start () {
		timer = 0;
		QTE.SetActive(true);
		LoadButtonImage();
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(Input.GetKeyDown(KeyCode.A) && button == "a"){
			QTE.SetActive(false);
			buttonA.SetActive(false);
			Destroy(gameObject);
		}
		else if(Input.GetKeyDown(KeyCode.S) && button == "s"){
			QTE.SetActive(false);
			buttonS.SetActive(false);
			Destroy(gameObject);
		}
		else if(Input.GetKeyDown(KeyCode.W) && button == "w"){
			QTE.SetActive(false);
			buttonW.SetActive(false);
			Destroy(gameObject);
		}
		else if(Input.GetKeyDown(KeyCode.D) && button == "d"){
			QTE.SetActive(false);
			buttonD.SetActive(false);
			Destroy(gameObject);
		}
		else if(Input.GetKeyDown(KeyCode.RightShift) && button == "shift"){
			QTE.SetActive(false);
			buttonShift.SetActive(false);
			Destroy(gameObject);
		}
		else if(Input.GetKeyDown(KeyCode.LeftShift) && button == "shift"){
			QTE.SetActive(false);
			buttonShift.SetActive(false);
			Destroy(gameObject);
		}
		if(timer >= 2f && invincible == false){
			Red.SetActive(true);
			playerHealth2.TakeDamage (attackDamage);
			invincible = true;
			if(button == "a")
			{
				buttonA.SetActive(false);
			}
			else if(button == "s")
			{
				buttonS.SetActive(false);
			}
			else if(button == "w")
			{
				buttonW.SetActive(false);
			}
			else if(button == "d")
			{
				buttonD.SetActive(false);
			}
			else if(button == "shift")
			{
				buttonShift.SetActive(false);
			}
			QTE.SetActive(false);
			Destroy(gameObject);
		}
	}

	void LoadButtonImage()
	{
		if(button == "a")
		{
			buttonA.SetActive(true);
		}
		else if(button == "s")
		{
			buttonS.SetActive(true);
		}
		else if(button == "w")
		{
			buttonW.SetActive(true);
		}
		else if(button == "d")
		{
			buttonD.SetActive(true);
		}
		else if(button == "shift")
		{
			buttonShift.SetActive(true);
		}
	}
}

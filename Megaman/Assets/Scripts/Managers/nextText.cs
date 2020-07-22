using UnityEngine;
using System.Collections;

public class nextText : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Time.timeScale = 0;
		if(Input.GetButtonDown("Submit")){
			Time.timeScale = 1;
			this.gameObject.SetActive(false);
		}
	}
}

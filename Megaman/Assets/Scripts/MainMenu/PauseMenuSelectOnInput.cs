using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PauseMenuSelectOnInput : MonoBehaviour {

	public EventSystem eventSystem;
	public GameObject selectedObject;

	PauseManager pauseManager;

	private bool buttonSelected;

	// Use this for initialization
	void Start () {
		pauseManager = GetComponent<PauseManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxisRaw("Vertical") != 0 && buttonSelected == false && pauseManager.isPausing == true)
		{
			eventSystem.SetSelectedGameObject(selectedObject);
			buttonSelected = true;
		}
	}

	private void OnDisable()
	{
		buttonSelected = false;
	}
}

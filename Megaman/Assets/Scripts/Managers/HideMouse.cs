﻿using UnityEngine;
using System.Collections;

public class HideMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	

}

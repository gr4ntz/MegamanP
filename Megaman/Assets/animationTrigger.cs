using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class animationTrigger : MonoBehaviour {

	public string trigger;

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponentInParent<Animator>();
		anim.SetTrigger(trigger);
	}
}

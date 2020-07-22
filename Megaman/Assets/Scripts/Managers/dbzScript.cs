using UnityEngine;
using System.Collections;

public class dbzScript : MonoBehaviour {

	public Animator anim;
	float timer=0f;
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer >= 0.2f)
		{
			anim.SetBool("6",true);
			anim.SetBool("7",false);
			anim.SetBool("5re",false);
		}
		if(timer >= 0.4f)
		{
			anim.SetBool("6",false);
			anim.SetBool("7",true);
			anim.SetBool("5re",false);
		}
		if(timer >= 0.6f)
		{
			anim.SetBool("6",false);
			anim.SetBool("7",false);
			anim.SetBool("5re",true);
			timer = 0f;
		}
	}
}

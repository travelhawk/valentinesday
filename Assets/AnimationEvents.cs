using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour {

	public GameObject valentine;
	public GameObject loveU;
	public GameObject credits;
	public Animation creditAnim;
	public ParticleSystem particles;


	public void showHappyValentine() {
		//valentine.SetActive (true);
		valentine.GetComponent<FadeObjectInOut>().FadeIn(3.5f);
		particles.Play ();
	}

	public void showLoveU() {
		loveU.SetActive (true);
	}

	public void showCredits() {
		//UnityEngine.SceneManagement.SceneManager.LoadScene ("credits");
		creditAnim.Play ();
		credits.SetActive(true);
	}
		
}

using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AudioSource BGM = GetComponent<AudioSource>();
//		BGM.Play(44100);
		BGM.PlayDelayed(0.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

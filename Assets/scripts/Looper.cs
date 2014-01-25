using UnityEngine;
using System.Collections;

public class Looper : MonoBehaviour {

	//this script will not be used anymore parhups..
	
	public GameObject respawnpoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D coll){
		coll.gameObject.transform.position = respawnpoint.transform.position;
		GameController.loop();
	}
}

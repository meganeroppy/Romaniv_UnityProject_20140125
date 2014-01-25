using UnityEngine;
using System.Collections;

public class Btn_run : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void Update () {
		
	}

	void OnMouseDown(){
		if(Input.GetMouseButton(0))
			Application.LoadLevel("run");
	}

	// Update is called once per frame


}

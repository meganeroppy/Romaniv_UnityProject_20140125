using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	//system
//	private float w = Screen.width;
//	private float h = Screen.height;

	//status
//	private int score = 0;
//	private float advance = 0;
	
	//button
//	public Texture jump_button;
//	public Texture slap_button;
//	private float button_width = 160.0f;
//	private float button_height = 100.0f;

//	private Rect score_field;
//	private Rect advance_field;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
//		GUI.TextField(advance_field, "advance" + advance.ToString() + "CM");
//		GUI.TextField(score_field, "Collected Hair" + score.ToString());
		
		
//		if(GUI.Button(new Rect(w - button_width, h - button_height, button_width, button_height), jump_button, GUIStyle.none)){
//			GameObject.Find("romaniv").SendMessage("jump", SendMessageOptions.RequireReceiver);
//		}
		
//		if(GUI.Button(new Rect(0, h - button_height, button_width, button_height), slap_button, GUIStyle.none)){
//			GameObject.Find("romaniv").SendMessage("slap", SendMessageOptions.RequireReceiver);
//		}
	}
}

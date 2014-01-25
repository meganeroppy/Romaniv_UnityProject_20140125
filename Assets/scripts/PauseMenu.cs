using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	private float w;
	private float h;
	private float margin_side;
	private float margin_updown;
	// Use this for initialization
	public Texture btn_restart;
	public Texture btn_resume;
	public Texture btn_quit2;
	
	private float slct_btn_width = 300.0f;
	private float slct_btn_height = 80.0f;
	void Start () {
		w = GameController.w;
		h = GameController.h;
		margin_side = GameController.margin_side;
		margin_updown = GameController.margin_updown;

		GameController.pause();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		GUI.Box(new Rect (margin_side, margin_updown, w - (margin_side * 2), h - (margin_updown * 2)), " ");
		
		if(GUI.Button(new Rect(w * 0.5f - (slct_btn_width * 0.5f), h * 0.2f, slct_btn_width, slct_btn_height), btn_restart, GUIStyle.none)){
			Application.LoadLevel("run");
		}
		if(GUI.Button(new Rect(w * 0.5f - (slct_btn_width * 0.5f), h * 0.45f, slct_btn_width, slct_btn_height), btn_resume, GUIStyle.none)){
			GameController.resume();
			Destroy(this.gameObject);
		}

		if(GUI.Button(new Rect(w * 0.5f - (slct_btn_width * 0.5f), h * 0.7f, slct_btn_width, slct_btn_height), btn_quit2, GUIStyle.none)){
			Application.LoadLevel("title");
		}
	}
}

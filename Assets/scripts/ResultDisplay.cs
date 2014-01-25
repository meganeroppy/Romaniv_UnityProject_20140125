using UnityEngine;
using System.Collections;

public class ResultDisplay : MonoBehaviour {

	private float w;
	private float h;
	private float margin_side;
	private float margin_updown;
	// Use this for initialization
	public Texture btn_retry;
	public Texture btn_quit;

	private float slct_btn_width = 360.0f;
	private float slct_btn_height = 100.0f;
	void Start () {
		w = GameController.w;

		h = GameController.h;
		margin_side = GameController.margin_side;
		margin_updown = GameController.margin_updown;
	
	}

	void OnGUI(){
//		GUI.Box(new Rect (margin_side, margin_updown, w - (margin_side * 2), h - (margin_updown * 2)), BG_gameOver, GUIStyle.none);
		GUI.Box(new Rect (margin_side, margin_updown, w - (margin_side * 2), h - (margin_updown * 2)), " ");

		if(GUI.Button(new Rect(w * 0.5f - (slct_btn_width * 0.5f), h * 0.25f, slct_btn_width, slct_btn_height), btn_retry, GUIStyle.none)){
			Application.LoadLevel("run");
			//				reset ();
		}
		if(GUI.Button(new Rect(w * 0.5f - (slct_btn_width * 0.5f), h * 0.55f, slct_btn_width, slct_btn_height), btn_quit, GUIStyle.none)){
			Application.LoadLevel("title");
		}
	}
}

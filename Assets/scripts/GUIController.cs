using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

	//system
	private float w;
	private float h;
	private float margin_side;
	private float margin_updown;

	
	//Romaniv
	//public GameObject romaniv;
	private GameObject romaniv;
	
	//button
	public Texture2D tex_btn_jump;
	public Texture2D tex_btn_slap;
	public Texture2D tex_btn_pause;


	private float act_btn_width = 180.0f;
	private float act_btn_height = 120.0f;
	private float pause_btn_size = 60.0f;

	//score
	private Rect score_field;
	private Rect advance_field;

	public Texture tex_score;
	public Texture[] tex_num = new Texture[10];
	private float size_font_score;
	//private uint digit = 1;


	//Pause Menu
	public GameObject PauseMenu;
	
	// Use this for initialization
	void Start () {
		romaniv = GameObject.Find("Romaniv");
		w = GameController.w;
		h = GameController.h;
		margin_side = GameController.margin_side;
		margin_updown = GameController.margin_updown;
		advance_field = new Rect(w * 0.35f, h * 0.05f, w * 0.2f, h * 0.05f);
		score_field = new Rect(w * 0.05f, h * 0.05f, w * 0.2f, h * 0.05f);
		size_font_score = w * 0.05f;
	}
	
	void OnGUI(){

		//control with Keyboard
		if(Input.GetKey("j")){
			romaniv.SendMessage("jump",SendMessageOptions.DontRequireReceiver);
		}
		if(Input.GetKey("s")){
			romaniv.SendMessage("slap",SendMessageOptions.DontRequireReceiver);
		}

		GUI.TextField(advance_field, "advance : " + Mathf.Floor(GameController.advance).ToString() + " CM");


		//Score Display

		/*
		GUI.Box(new Rect(margin_side * 0.5f, margin_updown, 130, 130), tex_score, GUIStyle.none);

		digit = getDigits(GameController.score);

		for(uint i = 0 ; i < digit ; i++){
			if(i >= 1 ){
				GUI.Box(new Rect(margin_side * 3.5f - ( 0.8f * (i + 1)), margin_updown, size_font_score, size_font_score), tex_num[(int)GameController.score / 10], GUIStyle.none);
			}else{
				GUI.Box(new Rect(margin_side * 3.5f + ((margin_side *  0.8f) * (i + 1)), margin_updown, size_font_score, size_font_score), tex_num[(int)GameController.score % 10], GUIStyle.none);
			}
		}

		*/
		GUI.TextField(score_field, "Collected Hair : " + GameController.score.ToString());

		//
		bool btn_jump = GUI.Button(new Rect(Screen.width - act_btn_width, Screen.height - act_btn_height, act_btn_width, act_btn_height), tex_btn_jump, GUIStyle.none);
		bool btn_slap = GUI.Button(new Rect(0, Screen.height - act_btn_height, act_btn_width, act_btn_height), tex_btn_slap, GUIStyle.none);
		if(GameController.cur_scene != GameController.SCENE.PAUSE){
			if( GUI.Button(new Rect(w - pause_btn_size - margin_side, margin_updown, pause_btn_size, pause_btn_size), tex_btn_pause, GUIStyle.none)){
				GameController.cur_scene = GameController.SCENE.PAUSE;
				GameObject pauseMenuPrefab = Instantiate(PauseMenu) as GameObject;
			}
		}
		if(btn_jump){
			romaniv.SendMessage("jump",SendMessageOptions.DontRequireReceiver);
		}
		if(btn_slap){
			romaniv.SendMessage("slap",SendMessageOptions.DontRequireReceiver);
		}

	}

	uint getDigits(int num){
		if(num < 10){
			return 1;
		}
		uint numOfDigits = 1;
		while(num >= 10){
			num /= 10;
			numOfDigits++;
		}
		return numOfDigits;

	}
}


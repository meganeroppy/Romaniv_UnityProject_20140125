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


	private float act_btn_width;// = 180.0f;
	private float act_btn_height;// = 120.0f;
	private float pause_btn_size;// = 60.0f;

	//collected hair
	private Rect score_field;
	private Rect advance_field;

	public Texture2D[] tex_num = new Texture2D[10];
	public Texture2D tex_ke;
	//private float size_tex;
	public Texture2D tex_hon;
	private float size_font_score;
	private uint digit = 1;

	//advance
	public Texture2D tex_hitohada;
	public Texture2D tex_cm;


	//Pause Menu
	public GameObject PauseMenu;
	
	// Use this for initialization
	void Start () {
		romaniv = GameObject.Find("Romaniv");
		w = GameController.w;
		h = GameController.h;
		act_btn_width = w * 0.22f;
		act_btn_height = h * 0.26f;
		pause_btn_size = w * 0.07f;
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
		if(Input.GetKey("p") && GameController.cur_scene != GameController.SCENE.PAUSE){
			Pause();
		}


		//Score Display
	
		GUI.Box(new Rect(w * 0.008f, margin_updown, size_font_score, size_font_score), tex_ke, GUIStyle.none);

		digit = getDigits(GameController.score);

		for(uint i = digit ; i != 0 ; i--){
			if(i > 1 ){	
				int tmp = (int)GameController.score;
				//Debug.Log(tmp);
				
				for(uint j = i ; j > 1 ; j--){
					tmp /= 10;
				}
				tmp %= 10;
				GUI.Box(new Rect(w * 0.13f - ( w * 0.03f * i), margin_updown, size_font_score, size_font_score), tex_num[tmp], GUIStyle.none);
				
			}else{
				int tmp = (int)GameController.advance;
				tmp %= 10;
				
				GUI.Box(new Rect(w * 0.13f - ( w * 0.03f * i), margin_updown, size_font_score, size_font_score), tex_num[(int)GameController.score % 10], GUIStyle.none);
			}
		}

		GUI.Box(new Rect(w * 0.14f, margin_updown, size_font_score, size_font_score), tex_hon, GUIStyle.none);


		//GUI.TextField(score_field, "Collected Hair : " + GameController.score.ToString());

		//GUI.TextField(advance_field, "advance : " + Mathf.Floor(GameController.advance).ToString() + " CM");

		GUI.Box(new Rect(w * 0.2f, margin_updown * 0.5f, size_font_score * 3.0f, size_font_score * 3.0f), tex_hitohada, GUIStyle.none);

		digit = getDigits((int)GameController.advance);

		for(uint i = digit ; i != 0 ; i--){
			if(i > 1 ){	
				int tmp = (int)GameController.advance;
				//Debug.Log(tmp);

				for(uint j = i ; j > 1 ; j--){
					tmp /= 10;
				}
				tmp %= 10;
				GUI.Box(new Rect(w * 0.43f - ( w * 0.03f * i), margin_updown, size_font_score, size_font_score), tex_num[tmp], GUIStyle.none);

			}else{
				int tmp = (int)GameController.advance;
				tmp %= 10;

				GUI.Box(new Rect(w * 0.43f - ( w * 0.03f * i), margin_updown, size_font_score, size_font_score), tex_num[(int)GameController.advance % 10], GUIStyle.none);
			}
		}

		GUI.Box(new Rect(w * 0.45f, margin_updown * 0.5f, size_font_score * 1.5f, size_font_score * 1.5f), tex_cm, GUIStyle.none);


		//
		bool btn_jump = GUI.Button(new Rect(Screen.width - act_btn_width, Screen.height - act_btn_height, act_btn_width, act_btn_height), tex_btn_jump, GUIStyle.none);
		bool btn_slap = GUI.Button(new Rect(0, Screen.height - act_btn_height, act_btn_width, act_btn_height), tex_btn_slap, GUIStyle.none);
		if(GameController.cur_scene != GameController.SCENE.PAUSE){
			if( GUI.Button(new Rect(w - pause_btn_size - margin_side, margin_updown, pause_btn_size, pause_btn_size), tex_btn_pause, GUIStyle.none)){
				Pause();
			}
		}
		if(btn_jump){
			romaniv.SendMessage("jump",SendMessageOptions.DontRequireReceiver);
		}
		if(btn_slap){
			romaniv.SendMessage("slap",SendMessageOptions.DontRequireReceiver);
		}

	}

	void Pause(){
		GameController.cur_scene = GameController.SCENE.PAUSE;
		GameObject pauseMenuPrefab = Instantiate(PauseMenu) as GameObject;
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


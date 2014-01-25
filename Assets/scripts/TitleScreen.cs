using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {

	private int w = Screen.width;
	private int h = Screen.height;

	//GUIStyle
	public GUIStyle GUI_btn_run;
	public float buttonLatio = 1f; 

	//logo
	public Texture title_logo;
	private float logo_width;
	private float logo_height;

	//run
//	public Texture btn_run;
	public Texture btn_run;
	private float btn_run_width;
	private float btn_run_height;

	//option
	public Texture btn_option;
	private float mini_btn_width;
	private float mini_btn_height;
	//sound
	public Texture btn_sound;

	//ranking
	public Texture btn_ranking;

	//tweet
	public Texture btn_tweet;

	//facebook
	public Texture btn_facebook;

	//credit
	public GUIStyle format_credits;
	private bool displaying = false;

	// Use this for initialization
	void Start () {
		logo_width = w * 0.8f;
		logo_height = h * 0.3f;

//		var textureAspectRaito = btn_run.height / btn_run.width;
//		btn_run_width = w * buttonLatio;
//		btn_run_height = btn_run_width * buttonLatio;
		btn_run_width = w;
		btn_run_height = h * 0.3f;

		mini_btn_width = w * 0.12f;
		mini_btn_height = mini_btn_width;
	}
	
	// Update is called once per frame
	void Update () {	
//		var textureAspectRaito = btn_run.height / btn_run.width;
//		btn_run_width = w * buttonLatio;
//		btn_run_height = btn_run_width * buttonLatio;
	}

	void OnGUI(){
		GUI.DrawTexture(new Rect(Screen.width * 0.5f - (logo_width * 0.5f), 0, logo_width, logo_height), title_logo);

		if(GUI.Button(new Rect(w * 0.7f - (btn_run_width * 0.5f), h * 0.28f, btn_run_width, btn_run_height), btn_run, GUI_btn_run)){//
			print ("RUN!");
			Application.LoadLevel("run");
		}

		if(GUI.Button(new Rect(w * 0.19f, h * 0.59f, mini_btn_width, mini_btn_height), btn_tweet, GUIStyle.none)){
			print ("Tweet!");
			Application.OpenURL("www.twitter.com");
		}
		if(GUI.Button(new Rect(w * 0.32f, h * 0.59f, mini_btn_width, mini_btn_height), btn_facebook, GUIStyle.none)){
			print ("Facebook!");
			Application.OpenURL("www.facebook.com");
		}
		if(GUI.Button(new Rect(w * 0.45f, h * 0.59f, mini_btn_width, mini_btn_height), btn_ranking, GUIStyle.none)){
			print ("Ranking!");
				Application.OpenURL("www.amazon.co.jp");
		}
		if(GUI.Button(new Rect(w * 0.58f, h * 0.59f, mini_btn_width, mini_btn_height), btn_option, GUIStyle.none)){
			print ("Option!");
		}
		if(GUI.Button(new Rect(w * 0.71f, h * 0.59f, mini_btn_width, mini_btn_height), btn_sound, GUIStyle.none)){
			print ("Sound!");
		}

		if(GUI.Button(new Rect(w * 0.92f, h * 0.92f, w * 0.03f, h * 0.04f), "?")){
			displaying = !displaying;
		}
		if(displaying){
			GUI.Box(new Rect(0, 0, w * 0.3f, h), "#STAFF CREDIT#\n\n", format_credits);

			GUI.Box(new Rect(0, 0, w, h), "PRODUCER -> CHIKA TAKEUCHI\nCHARACTER DESIGNER -> CHIKA TAKEUCHI\nINTERFACE DESIGNER -> MIZUKI KASHIWAGI\n GAME PROGRAMMER -> WATARU FUKUSHIMA", format_credits);
			
		}

	}
}

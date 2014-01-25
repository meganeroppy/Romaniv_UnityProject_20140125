using UnityEngine;
using System.Collections;

public class GameController: MonoBehaviour {

	//status
	public enum SCENE{START, RUN, RESULT, PAUSE};
	public static SCENE cur_scene;

	//Romaniv
	public GameObject romaniv;
	private GameObject romanivPrefab;
	//property
	public static int score;
	public static float advance;
	public static int numOfLoop;
	public static float w;
	public static float h;
	public static float margin_side;
	public static float margin_updown;

	//GUI
	public GameObject GUIController;
	private GameObject GCPrefab;


	void Awake(){
//		romanivPrefab = Instantiate(romaniv, GameObject.Find("DefaultPoint").transform.position, transform.rotation) as GameObject;
	}
	// Use this for initialization
	void Start () {

		Time.timeScale = 1;

		w = Screen.width;
		h = Screen.height;
		margin_side = w * 0.05f;
		margin_updown = h * 0.05f; 

		cur_scene = SCENE.START;
		score = 0;
		advance = 0.0f;
		numOfLoop = 0;


	}
	
	// Update is called once per frame
	void Update () {
		switch(cur_scene){
		case SCENE.START:
			GCPrefab = Instantiate( GUIController ) as GameObject;
			cur_scene = SCENE.RUN;
			break;
		case SCENE.RUN:
			break;
		case SCENE.RESULT:
				Destroy(GCPrefab);
			break;
		case SCENE.PAUSE:
			break;
		default:
			break;
		}
	}

	public static void loop(){
		numOfLoop += 1;
		int i = 0;
		for(;i<10;i++){
			GameObject.Find("hair_point" + (i+1).ToString()).SendMessage("respawn");
		}

	}
	public static void switchScene(string nextScene){
		if(nextScene == "result"){
			cur_scene = SCENE.RESULT;
		}else if(nextScene == "run"){
			cur_scene = SCENE.RUN;
		}else{
			print ("exception occurred.");
		}
	}

	public static void pause(){
		Time.timeScale = 0;
		cur_scene = SCENE.PAUSE;
	}

	public static void resume(){
		Time.timeScale = 1;
		cur_scene = SCENE.RUN;
	}

	void reset(){
		score = 0;
		advance = 0;
		//transform.position = (GameObject.Find("respawnPoint").transform.position);
		
	}
}

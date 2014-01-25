using UnityEngine;
using System.Collections;

public class Sky : MonoBehaviour {
	//public GameObject daytime;
	//public GameObject sunset;
	//public GameObject night;
	//public GameObject Character;
	public Texture2D daytime;
	public Texture2D sunset;
	public Texture2D night;
	private Texture2D cur_tex;

	//private GameObject cur_pic;



	// Use this for initialization
	void Start () {
		cur_tex = daytime;
		renderer.material.SetTexture("tex", cur_tex);
	
	}
	
	// Update is called once per frame
	void Update () {
		//this.transform.position = new Vector3(Character.transform.position.x, Character.transform.position.y, Character.transform.position.z + 30.0f);
		if(GameController.score % 10 == 0){
			switchPic();
		}
	}

	void switchPic(){
		if (cur_tex == daytime){
			Debug.Log("daytime>sunset");
			cur_tex = sunset;
			renderer.material.SetTexture("tex", cur_tex);

			//Destroy(cur_pic.gameObject);
			//cur_pic = Instantiate( sunset, this.transform.position, this.transform.rotation) as GameObject;
		}else if(cur_tex == sunset){
			Debug.Log("sunset>night");

			cur_tex = night;

			renderer.material.SetTexture("tex", cur_tex);
			//Destroy(cur_pic.gameObject);
			//cur_pic = Instantiate( daytime, this.transform.position, this.transform.rotation) as GameObject;
		}else{
			Debug.Log("night>daytime");

			cur_tex = daytime;
			renderer.material.SetTexture("tex", cur_tex);

			}


	}
}

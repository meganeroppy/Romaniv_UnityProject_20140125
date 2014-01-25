using UnityEngine;
using System.Collections;

public class BG : MonoBehaviour {

	private enum TIME{DAYTIME, SUNSET, NIGHT};
	private TIME cur_time;
	private int numOfLoop;

	public Sprite daytime;
	public Sprite sunset;
	public Sprite night;



	// Use this for initialization
	void Start () {
		cur_time = TIME.DAYTIME;
		numOfLoop = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(numOfLoop != GameController.numOfLoop){
			switchTime();
			numOfLoop = GameController.numOfLoop;
		}
	
	}

	void switchTime(){
		switch(cur_time){
			case TIME.DAYTIME:
				cur_time = TIME.SUNSET;
				this.GetComponent<SpriteRenderer>().sprite = sunset;
				break;
			case TIME.SUNSET:
				cur_time = TIME.NIGHT;
			this.GetComponent<SpriteRenderer>().sprite = night;
				break;
			case TIME.NIGHT:
				cur_time = TIME.DAYTIME;
			this.GetComponent<SpriteRenderer>().sprite = daytime;
			break;
			default:
				break;
		}
	}
}

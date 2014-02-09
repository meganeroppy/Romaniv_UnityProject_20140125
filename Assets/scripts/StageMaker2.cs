using UnityEngine;
using System.Collections;

public class StageMaker2 : MonoBehaviour {
	
	//Making pace = 19.2f;
	
	public GameObject[] stage = new GameObject[16];
	private float[] leftEndPos = new float[16];
	private float[] rightEndPos = new float[16];
	private GameObject stagePrefab;
	public GameObject Romaniv;

	public GameObject makeSwitch;
	private GameObject makeSwitchPrefab;
	public GameObject raycaster;
	private GameObject raycasterPrefab;
	
	private bool readyToMake = true;
	public float distanceToRomaniv;
	public float distanceToSwitch;
	private float switch_x;
	private int seed;

	public bool SafeRun = false;
	//private float GapOfPosY = 0.0f;
	private float curRightEnd = 0.0f;


	private int cnt = 0;

	// Use this for initialization
	void Start () {
		this.transform.position = new Vector3(Romaniv.transform.position.x + distanceToRomaniv, Romaniv.transform.position.y, this.transform.position.z);

		
		curRightEnd = 0.0f;

		leftEndPos[0] = 0.0f;	rightEndPos[0] = 0.0f;
		leftEndPos[1] = -0.3f;	rightEndPos[1] = 1.0f;
		leftEndPos[2] = 1.0f;	rightEndPos[2] = 0.5f;
		leftEndPos[3] = 0.5f;	rightEndPos[3] = 0.0f;
		leftEndPos[4] = 0.0f;	rightEndPos[4] = -1.5f;
		leftEndPos[5] = -1.5f;	rightEndPos[5] = 0.2f;
		leftEndPos[6] = 0.2f;	rightEndPos[6] = 0.1f;
		leftEndPos[7] = 0.1f;	rightEndPos[7] = 0.1f;
		leftEndPos[8] = 0.1f;	rightEndPos[8] = 0.1f;
		leftEndPos[9] = 0.1f;	rightEndPos[9] = 0.1f;
		leftEndPos[10] = 0.1f;	rightEndPos[10] = -0.5f;
		leftEndPos[11] = -0.3f;	rightEndPos[11] = 0.0f;
		leftEndPos[12] = 0.0f;	rightEndPos[12] = 0.0f;
		leftEndPos[13] = 0.0f;	rightEndPos[13] = 0.0f;
		leftEndPos[14] = 0.0f;	rightEndPos[14] = -3.0f;
		leftEndPos[15] = -3.0f;	rightEndPos[15] = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3(Romaniv.transform.position.x + distanceToRomaniv, this.transform.position.y, this.transform.position.z);

		if(readyToMake){
			readyToMake = false;
			Make ();
		}else if(this.transform.position.x - switch_x >= distanceToSwitch){
			readyToMake = true;
		}

	}

	void Make(){
		//seed = (int)Mathf.Floor(Random.value * 10.0f % 16.0f);
		seed = cnt;
		if(cnt == 7){
			cnt+=2;
		}else if(cnt >= 15){
			cnt = 0;
		}else{
			cnt++;
		}

		//Vector3 nextPos = new Vector3(this.transform.position.x, leftEnd[seed], 0.0f);
		stagePrefab = Instantiate(stage[seed], new Vector3(this.transform.position.x, this.transform.position.y + (curRightEnd - leftEndPos[seed]), this.transform.position.z), this.transform.rotation) as GameObject;
		//Debug.Log("leftEndPos[seed]=" + leftEndPos[seed].ToString() + " : curRightEnd = " + curRightEnd.ToString() );
		makeSwitchPrefab = Instantiate(makeSwitch, this.transform.position, this.transform.rotation) as GameObject;
		switch_x = makeSwitchPrefab.transform.position.x;
		curRightEnd = rightEndPos[seed];
		if(!SafeRun){
			raycasterPrefab = Instantiate(raycaster, new Vector3(this.transform.position.x - 4.0f, this.transform.position.y + 10.0f, this.transform.position.z), this.transform.rotation) as GameObject;
			raycasterPrefab = Instantiate(raycaster, new Vector3(this.transform.position.x + 4.0f, this.transform.position.y + 10.0f, this.transform.position.z), this.transform.rotation) as GameObject;
		}
	}



}

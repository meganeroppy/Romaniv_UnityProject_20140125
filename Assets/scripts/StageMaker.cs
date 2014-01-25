using UnityEngine;
using System.Collections;

public class StageMaker : MonoBehaviour {

	//Making pace = 19.2f;

	public GameObject[] stage = new GameObject[16];
	private float[] leftEnd = new float[16];
	private float[] rightEnd = new float[16];
	private GameObject stagePrefab;
	public GameObject Romaniv;



	public float distanceToRomaniv;
	private int seed;
	private float readyToMake = 0.0f;
	// Use this for initialization
	void Start () {
		//Romaniv_x = Romaniv.transform.position.x + 5.0f;



		for(int i=0 ; i>16 ; i++){
			leftEnd[i] = 0.0f;
			rightEnd[i] = 0.0f;
		}


	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3(Romaniv.transform.position.x + distanceToRomaniv, this.transform.position.y, this.transform.position.z);

		//Debug.Log( Mathf.Floor(Time.realtimeSinceStartup) % 4);
		//this.transform.Translate(0.2f, 0.0f, 0.0f);
		if( Mathf.Floor(Time.realtimeSinceStartup) % 2.0f == 0){
			Debug.Log("seed = " + seed.ToString());
			if(readyToMake <= 0.0f){
				readyToMake = 3.0f;
				seed = (int)Mathf.Floor(Random.value * 10.0f % 16.0f);
				print (seed);
				//Vector3 nextPos = new Vector3(this.transform.position.x, leftEnd[seed], 0.0f);
				stagePrefab = Instantiate(stage[seed], this.transform.position, this.transform.rotation) as GameObject;
			}else{
				readyToMake -= 0.05f;
			}
		}
	}
}

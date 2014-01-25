using UnityEngine;
using System.Collections;

public class Obstacle: MonoBehaviour {

	//status
	private enum STATUS{ALIVE, DEAD};
	private STATUS cur_status;

	//Game Objects
	public GameObject[] obstacle = new GameObject[5];
	private GameObject obstaclePrefab;
	int seed;


	// Use this for initialization
	void Start () {

		cur_status = STATUS.ALIVE;
		seed = (int)Mathf.Floor(Random.value * 10.0f % 5.0f);
		obstaclePrefab = Instantiate(obstacle[seed], this.transform.position + new Vector3(0, 1.2f,0), this.transform.rotation) as GameObject;

		obstaclePrefab.GetComponent<CircleCollider2D>().radius = 1.0f;
	
		Destroy(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public bool CheckisAlive(){
		if(cur_status == STATUS.ALIVE){
			return true;
		}else{
			return false;
		}
	}
}

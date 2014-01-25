using UnityEngine;
using System.Collections;

public class HairPoint: MonoBehaviour {
//	private float respawn_delay = 3.0f;
//	private bool respawnable = false;
	private float t_time;
	
	public GameObject hair;

	private float hair_height;
	// Use this for initialization
	void Start () {
		//this.renderer.enabled = false;
		hair_height = hair.transform.lossyScale.y;
		Instantiate(hair, transform.position + new Vector3(0,2,0), transform.rotation);
		hair.transform.Translate(new Vector3(0, -hair_height ,0));

		Destroy(this.gameObject);
	}
	
	// Update is called once per frame
/*	void Update () {
		if(!respawnable && Time.realtimeSinceStartup - t_time >= respawn_delay){
			respawnable = true;
		}
		if(Mathf.Floor(Time.realtimeSinceStartup % 62.0f) == 0 && respawnable){
//			respawn();
		}

	}

	void respawn(){
		Instantiate(hair, gameObject.transform.position, gameObject.transform.rotation);
		respawnable = false;
		t_time = Time.realtimeSinceStartup;

	}
	*/
}

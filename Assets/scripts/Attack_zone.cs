using UnityEngine;
using System.Collections;

public class Attack_zone : MonoBehaviour {

	public bool IS_INVISIBLE = false;
	private const float DELAY = 0.15f;
	private const float DURATION = 0.4f;
	public const float WAITTIME_TO_REUSE = 1.0f;
	public float timeToReuse;
	//public float duration = 5.0f;

	private float t_time;
	private bool hittable = false;

	// Use this for initialization
	void Start () {
		t_time = 0.0f;
		if(IS_INVISIBLE){
			transform.renderer.enabled = false;
		}
	}

	// Update is called once per frame
	void Update () {
		t_time += 1.0f * Time.deltaTime;

//		Debug.Log("prepare to slap : " + t_time.ToString());

		if(t_time >= DELAY && t_time < DELAY + DURATION){
//			Debug.Log("slapping : " + t_time.ToString());
			this.renderer.material.color = new Color(0xFF,0x00,0x00);
			if(!hittable){
				hittable = true;
			}
		}else if(t_time >= DELAY + DURATION){
//			Debug.Log("End of slapping : " + t_time.ToString());
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(hittable && other.gameObject.tag == "hair"){
			//print("attack_zone.OnTriggerEnter()");
//			Destroy(other.gameObject);
//			hittable = false;
		}
	}
}

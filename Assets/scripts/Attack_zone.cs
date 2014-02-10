using UnityEngine;
using System.Collections;

public class Attack_zone : MonoBehaviour {

	public bool IS_INVISIBLE = false;
	private const float DELAY = 0.15f;
	private const float DURATION = 0.32f;

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

		if(t_time >= DELAY && t_time < DELAY + DURATION){
			this.renderer.material.color = new Color(0xFF,0x00,0x00);
			if(!hittable){
				hittable = true;
			}
		}else if(t_time >= DELAY + DURATION){
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

using UnityEngine;
using System.Collections;

public class Hair : MonoBehaviour {

	private enum STATUS{ALIVE, DEAD};
	private STATUS cur_status;
	private float t_time;

	private Animator anim;
	// Use this for initialization
	void Start () {
		cur_status = STATUS.ALIVE;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		switch(cur_status){
		case STATUS.ALIVE:
				break;
		case STATUS.DEAD:
			if(Time.realtimeSinceStartup - t_time >= 2.0f)
				Destroy(this.gameObject);
			break;
		default:
			break;
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.tag == "attack_zone" && cur_status ==STATUS.ALIVE){
			anim.SetTrigger("death_t");
			transform.rigidbody2D.isKinematic = false;
			transform.rigidbody2D.AddForce(new Vector2(160, 300));
			t_time = Time.realtimeSinceStartup;
			GameController.score += 1;
			cur_status = STATUS.DEAD;

		}
	}

	public bool CheckisAlive(){
		if(cur_status == STATUS.ALIVE){
			return true;
		}else{
			return false;
		}
	}
}

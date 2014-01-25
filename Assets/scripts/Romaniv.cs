using UnityEngine;
using System.Collections;

public class Romaniv : MonoBehaviour {

	//system
	private float t_time;

	//status
	public float speed = 8.0f;
	public float jumpSpeed = 10.0f;
//	public float re_attack_delay = 0.5f;
//	private bool attackable = true;
	private enum STATUS{RUN, STOP, JUMP, SLAP, DEAD};
	private STATUS cur_status;
	private enum JUMP_STATUS{ACSEND, DESCEND};
	private JUMP_STATUS cur_j_status;
	private float cur_jumpSpeed;


	private bool gameOver = false;

	
	//gameover
	public GameObject resultDispley;

	private Animator anim;

	//game objects
	public GameObject attack_zone;
	public GameObject explosion;

	private GameObject ground;
	private CircleCollider2D circleCollider;


	private int playerLayer;
	private int groundLayer;

	private static  Vector2 tmp;
	
	
	
	// Use this for initialization
	void Start () {
		cur_j_status = JUMP_STATUS.DESCEND;
		//playerLayer = LayerMask.NameToLayer("Player");
		groundLayer = LayerMask.NameToLayer("Ground");

		ground = GameObject.FindWithTag("ground");
		circleCollider = this.GetComponent<CircleCollider2D>();

		cur_status = STATUS.JUMP;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log("cur_status = " + cur_status.ToString());

		/////////////
		/// 

		switch(cur_status){
			case STATUS.RUN:
		//		if(!attackable && t_time - Time.realtimeSinceStartup * Time.deltaTime >= re_attack_delay ){
		//			attackable = true;
		//		}

				transform.Translate(Vector2.right * speed * Time.deltaTime);	//walking right direction
				//transform.Translate(new Vector2(speed * Time.deltaTime, 0) );	//walking right direction
				
			GameController.advance += Time.deltaTime;
				break;
			case STATUS.STOP:
				break;
			case STATUS.JUMP:
				transform.Translate(Vector2.right * speed * Time.deltaTime);	//walking right direction
				GameController.advance += Time.deltaTime;

				switch(cur_j_status){
						case JUMP_STATUS.ACSEND:
							//Debug.Log("acsending..");

							transform.Translate(Vector2.up * cur_jumpSpeed * Time.deltaTime);
				cur_jumpSpeed += Physics.gravity.y * Time.deltaTime;
				//Debug.Log("cur_jumpSpeed = " + cur_jumpSpeed.ToString());
							if(cur_jumpSpeed <= 0.0f){
								cur_j_status = JUMP_STATUS.DESCEND;

							}
							break;
						case JUMP_STATUS.DESCEND:
					//Debug.Log("decsending..");
						//	if(IsGrounded()){
						//		print ("grounded!!");
						//		cur_status = STATUS.RUN;
								//				anim.SetTrigger("jump_end_t");
						//	}
							break;
						default:
							break;
					}	//End of switch_jump
				break;
			case STATUS.SLAP:
				transform.Translate(Vector2.right * speed * Time.deltaTime);	//walking right direction
				GameController.advance += Time.deltaTime;

				anim.SetTrigger("slap_t");
				GameObject atk = 
				 Instantiate(attack_zone, (new Vector3(this.transform.position.x + (float)1.5, this.transform.position.y - (float)0.5, 0)), Quaternion.identity) as GameObject;;
				atk.transform.parent = this.gameObject.transform;
				cur_status = STATUS.RUN;
				break;
			case STATUS.DEAD:
				if(Time.realtimeSinceStartup - t_time >= 3.0f && !gameOver){
					Instantiate(resultDispley);
				GameController.switchScene("result");
					gameOver = true;
				}
				break;
			default:
				break;
		}//end of switch_status

	}
	public void jump(){
		if(cur_status == STATUS.RUN){
			cur_jumpSpeed = jumpSpeed;
			anim.SetTrigger("jump_t");
			cur_status = STATUS.JUMP;
			cur_j_status = JUMP_STATUS.ACSEND;
		}
	}
	
	public void slap(){
		if(cur_status == STATUS.RUN){
			anim.SetTrigger("slap_t");
			cur_status = STATUS.SLAP;
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		//print ("get into an object -> " + coll.gameObject.name.ToString());
		if (coll.gameObject.tag == "hair"){
			if(coll.gameObject.GetComponent<Hair>().CheckisAlive()){
				explode ();
			}
		}else if(coll.gameObject.tag == "obstacle"){
			explode();
		}else{
			//Debug.Log("OnTriggerEnter2D was called, might have hit something. > " + coll.gameObject.name.ToString());
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		//print ("crash with an object -> " + coll.gameObject.name.ToString());
		if(coll.gameObject.tag == "ground" && cur_j_status == JUMP_STATUS.DESCEND){
			cur_status = STATUS.RUN;
		}else{
		//Debug.Log("OnCollisionEnter2D was called, might have hit something. > " + coll.gameObject.name.ToString());

		}
	}

	void explode(){
		cur_status = STATUS.DEAD;
		this.renderer.enabled = false;
		this.rigidbody2D.isKinematic = true;
		Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
		t_time = Time.realtimeSinceStartup;
	}
	bool IsGrounded(){
		Debug.Log("tmp = " + tmp.ToString() );
		tmp =  Physics2D.Raycast(this.transform.position, new Vector2(0, -1), 0.0f).point;
		
		GameObject exp = Instantiate(explosion, tmp, Quaternion.identity) as GameObject;
		return true;
//		return Physics.Raycast(transform.position, new Vector3(0, -1, 0), this.circleCollider.radius);
	}
}

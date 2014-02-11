using UnityEngine;
using System.Collections;

public class Romaniv : MonoBehaviour {

	//system
	private float wait_to_dispResult;

	private const float TIME_TO_REUSE_SLAP = 1.0f;
	private float wait_to_slap = 0.0f;
	private bool SlapIsReady = true;

	private const float TIME_TO_REUSE_JUMP = 1.0f;
	private float wait_to_jump = 0.0f;
	private bool JumpIsReady = true;

	private const float START_POS_X = 0.0f;

	//status
	public float speed = 7.0f;
	public float jumpForce = 650.0f;

	public enum STATUS{RUN, STOP, JUMP, SLAP, DEAD};
	public STATUS cur_status;
	public enum JUMP_STATUS{ACSEND, DESCEND};
	public JUMP_STATUS cur_j_status;

	private const float MAX_SPEED = 5.0f;

	private bool gameOver = false;

	
	//gameover
	public GameObject resultDispley;

	private Animator anim;

	//game objects
	public GameObject attack_zone;
	public GameObject explosion;
	private GameObject ground;
	private CircleCollider2D circleCollider;
	private GameObject mainCamera;


	// Use this for initialization
	void Start () {
		mainCamera = transform.FindChild("Main Camera").gameObject;
		cur_j_status = JUMP_STATUS.ACSEND;

		ground = GameObject.FindWithTag("ground");
		circleCollider = this.GetComponent<CircleCollider2D>();

		cur_status = STATUS.JUMP;
		anim = GetComponent<Animator>();
	}

	void Update(){


		if(!SlapIsReady){
			wait_to_slap -= 1.0f * Time.deltaTime;
			if(wait_to_slap <= 0.0f){
				SlapIsReady = true;
			}
		}

		if(!JumpIsReady){
			wait_to_jump -= 1.0f * Time.deltaTime;
			if(wait_to_jump <= 0.0f){
				JumpIsReady = true;
			}
		}
	}
	
	void FixedUpdate () {

		GameController.advance = (this.transform.position.x - START_POS_X) / 10.0f ;

//		Debug.Log("cur_status = " + cur_status.ToString());

		//print("velocity.y = " + rigidbody2D.velocity.y);

		switch(cur_status){
			case STATUS.RUN:
		//		if(!attackable && wait_to_dispResult - Time.realtimeSinceStartup * Time.deltaTime >= re_attack_delay ){
		//			attackable = true;
		//		}

			//this.rigidbody2D.AddForce( new Vector2(speed * Time.deltaTime, 0.0f));	//walking right direction
			transform.Translate(Vector2.right * speed * Time.deltaTime);	//walking right direction
				
			//GameController.advance += Time.deltaTime;

				break;
			case STATUS.STOP:
				break;
			case STATUS.JUMP:
				//rigidbody2D.AddForce(Vector2.right * speed * Time.deltaTime);	//walking right direction
				transform.Translate(Vector2.right * speed * Time.deltaTime);	//walking right direction
			//	GameController.advance += Time.deltaTime;


			//print(cur_jumpSpeed);
				switch(cur_j_status){

						case JUMP_STATUS.ACSEND:
							//Debug.Log("acsending..");
//							rigidbody2D.AddForce(Vector2.up * cur_jumpSpeed);
//							cur_jumpSpeed += Physics2D.gravity.y * Time.deltaTime;
							//Debug.Log("cur_jumpSpeed = " + cur_jumpSpeed.ToString());
							if(rigidbody2D.velocity.y < 0){
								cur_j_status = JUMP_STATUS.DESCEND;

							}
							break;
						case JUMP_STATUS.DESCEND:
						//	Debug.Log("decsending..");
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
				//rigidbody2D.AddForce(Vector2.right * speed * Time.deltaTime);	//walking right direction
			//	GameController.advance += Time.deltaTime;

				anim.SetTrigger("slap_t");
				GameObject atk = 
				 Instantiate(attack_zone, (new Vector3(this.transform.position.x + (float)1.5, this.transform.position.y - (float)0.5, 0)), Quaternion.identity) as GameObject;;
				atk.transform.parent = this.gameObject.transform;
				cur_status = STATUS.RUN;
				break;
			case STATUS.DEAD:
				if(Time.realtimeSinceStartup - wait_to_dispResult >= 3.0f && !gameOver){
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
		if(JumpIsReady){
			if(cur_status == STATUS.RUN){
				rigidbody2D.AddForce( new Vector2(0.0f, jumpForce));
				anim.SetTrigger("jump_t");
				cur_status = STATUS.JUMP;
				cur_j_status = JUMP_STATUS.ACSEND;
				wait_to_jump = TIME_TO_REUSE_JUMP;
				JumpIsReady = false;
			}
		}
	}
	
	public void slap(){
		if(SlapIsReady){
			if(cur_status == STATUS.RUN){
				anim.SetTrigger("slap_t");
				cur_status = STATUS.SLAP;
				wait_to_slap = TIME_TO_REUSE_SLAP;
				SlapIsReady = false;
			}
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
		if(coll.gameObject.tag == "ground" && cur_status != STATUS.DEAD){
			anim.SetTrigger("run_t");
			cur_status = STATUS.RUN;
			cur_j_status = JUMP_STATUS.ACSEND;
		}else{
		//Debug.Log("OnCollisionEnter2D was called, might have hit something. > " + coll.gameObject.name.ToString());

		}
	}

	void explode(){
		cur_status = STATUS.DEAD;
		this.renderer.enabled = false;
		Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
		wait_to_dispResult = Time.realtimeSinceStartup;
		this.transform.DetachChildren();
	//	mainCamera.transform.parent = null;
	}

	/*
	bool IsGrounded(){
		Debug.Log("tmp = " + tmp.ToString() );
		tmp =  Physics2D.Raycast(this.transform.position, new Vector2(0, -1), 0.0f).point;
		
		GameObject exp = Instantiate(explosion, tmp, Quaternion.identity) as GameObject;
		return true;
//		return Physics.Raycast(transform.position, new Vector3(0, -1, 0), this.circleCollider.radius);
	}
	*/
}

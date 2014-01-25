using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public float duration = 1.0f;

	public GameObject ojisan;
	public GameObject ojichan;
	public GameObject onisan;
	private GameObject picPrefab;
		// Use this for initialization
	void Start () {
		Destroy(gameObject, duration);
		if(GameController.score >= 25){
			picPrefab = Instantiate(onisan, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 2.0f), gameObject.transform.rotation) as GameObject;
		}else if(GameController.score >= 50){
			picPrefab = Instantiate(ojisan, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 2.0f), gameObject.transform.rotation) as GameObject;
		}else{
			picPrefab = Instantiate(ojichan, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 2.0f), gameObject.transform.rotation) as GameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {	
	}
}

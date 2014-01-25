﻿using UnityEngine;
using System.Collections;

public class Raycaster : MonoBehaviour {

	public GameObject hairPoint;
	private GameObject hairPointPrefab;
	public GameObject obstacle;
	private GameObject obstaclePrefab;
	private RaycastHit2D RootPos; 
	private Vector2 RayOrigin;
	private Vector2 direction;

	private int layerMask = LayerMask.NameToLayer("Ground"); 
	// Use this for initialization
	void Start () {
		//this.renderer.enabled = false;

		//Debug.Log("layerMask = " + layerMask.ToString());

		int seed = (int)Mathf.Floor(Random.value * 10.0f % 5.0f);

		//Debug.Log(seed);
		RayOrigin = this.transform.position;
		RootPos =  Physics2D.Raycast( RayOrigin, new Vector2(0.0f, -10.0f), 100.0f);
		//Debug.Log( RootPos.collider);

		if(seed <= 3){
			hairPointPrefab = Instantiate(hairPoint, RootPos.point, this.transform.rotation) as GameObject;
		}else{
			obstaclePrefab = Instantiate(obstacle, RootPos.point, this.transform.rotation) as GameObject;
		}
		Destroy(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {

	}
}

﻿using UnityEngine;
using System.Collections;

public class PlayerControllerTwo : MonoBehaviour {
	public float moveSpeed = 0.1f;
	public float turnSpeed = 5f;

	//public GameObject[] doors;
	public GameObject rightDoor;
	public GameObject leftDoor;
	public GameObject camCtrl;
	public float doorSlide = 5f;
	private bool levelComplete = false;

	public GameObject popUp;

	Vector3 rightOriginPos;
	Vector3 leftOriginPos;


	// Use this for initialization
	void Start () {
		levelComplete = false;
		// doors = new GameObject[2];
		rightOriginPos = rightDoor.transform.position;
		leftOriginPos = leftDoor.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		// move the doors open and close them
		if(transform.position.z < -765f && transform.position.z > -777f){
			if(rightOriginPos.x - rightDoor.transform.position.x < doorSlide) {
				rightDoor.transform.position += new Vector3(-moveSpeed, 0f, 0f);
			}
			if(leftDoor.transform.position.x - leftOriginPos.x < doorSlide) {
				leftDoor.transform.position += new Vector3(moveSpeed, 0f, 0f);
			}
		}
		else{
			if(leftDoor.transform.position.x > leftOriginPos.x){
				leftDoor.transform.position += new Vector3(-moveSpeed, 0f, 0f);
			}
			if(rightDoor.transform.position.x < rightOriginPos.x){
				rightDoor.transform.position += new Vector3(moveSpeed, 0f, 0f);
			}
		}	

		// check the key being pressed and move the player accordingly
		if (Input.GetKey (GameController.forwardKey)) {
			transform.position += transform.forward * moveSpeed;
			GameController.moveZ = "forward";

		}
		if ( Input.GetKey( GameController.leftKey ) ) {
			transform.position = transform.position + new Vector3( moveSpeed, 0f, 0f);
			GameController.moveX = "left";
		}
		if (Input.GetKey (GameController.rightKey)) {
			transform.position = transform.position + new Vector3 (-moveSpeed, 0f, 0f);
			GameController.moveX = "right";
		}
		if ( Input.GetKey( GameController.backKey ) ) {
			transform.position += -transform.forward * moveSpeed;
			GameController.moveZ = "backward";
		}
		if ( Input.GetKey( GameController.upKey ) ) {
			transform.position += transform.up * moveSpeed;
			GameController.moveY = "up";
		}
		if ( Input.GetKey( GameController.downKey ) ) {
			transform.position += -transform.up * moveSpeed;
			GameController.moveY = "down";
		}
		if (Input.GetKey(KeyCode.LeftArrow)){
			camCtrl.transform.Rotate(0.0f, Input.GetAxis("Horizontal") * turnSpeed, 0.0f);

		}
		if (Input.GetKey(KeyCode.RightArrow)){
			camCtrl.transform.Rotate(0.0f, Input.GetAxis("Horizontal") * turnSpeed, 0.0f);
		}

		// if the level is d
		if(levelComplete && Input.GetKey(KeyCode.Return)) {
			GameController.currentLevel++;
			Application.LoadLevel(GameController.currentLevel);
	
		}
	}

	void OnCollisionEnter (Collision hit){
		if(hit.transform.gameObject.tag == "levelComplete"){
			Debug.Log("Done!");
			popUp.SetActive(true);
			levelComplete = true;
		}
	}

}

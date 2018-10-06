﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Player_Camera : MonoBehaviour {

    Transform playerPosition;

    public float cameraSpeed;

    void Awake(){
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 targetPosition = new Vector3(playerPosition.position.x, playerPosition.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * cameraSpeed);
	}
}

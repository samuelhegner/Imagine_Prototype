﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_Cosmos : MonoBehaviour {

    float playerHeight;
    float playerStartHeight;
    public float cameraZoomStart;
    public float risingSpeed = 2;

    public float cameraZoomSpeed;
    public float tiltSpeed;

    Camera cam;

    Rigidbody2D rb;


	void Start () {
        playerStartHeight = transform.position.y;
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        playerHeight = transform.position.y;

        rb.velocity = new Vector2(Input.acceleration.x * tiltSpeed, risingSpeed);

        if (cameraZoomStart <= playerHeight - playerStartHeight) {
            cam.orthographicSize += cameraZoomSpeed;
        }
	}
}

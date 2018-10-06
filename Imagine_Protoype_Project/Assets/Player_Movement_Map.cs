using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_Map : MonoBehaviour {
    
    [SerializeField]
    bool tilt;

    Vector2 pointToMove;

    Rigidbody2D rb;


    float dirX, dirY;


    [SerializeField]
    float movementSpeed;

	void Awake () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {

        if (tilt == false)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                pointToMove = Camera.main.ScreenToWorldPoint(touch.position);
            }

            transform.position = Vector2.MoveTowards(transform.position, pointToMove, movementSpeed * Time.deltaTime);
        }
        else {
            dirX = Input.acceleration.x * movementSpeed;
            dirY = Input.acceleration.y * movementSpeed;
        }

    }

    void FixedUpdate()
    {
        if (tilt == true) {
            rb.velocity = new Vector2(dirX, dirY);
        }
    }
}
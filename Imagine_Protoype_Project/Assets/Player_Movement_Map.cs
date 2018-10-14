using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_Map : MonoBehaviour {
    
    [SerializeField]
    bool tilt;
    [SerializeField]
    bool selected;

    Vector2 pointToMove;

    Rigidbody2D rb;


    float dirX, dirY;

    GameObject SelectedSite;


    [SerializeField]
    float movementSpeed;

	void Awake () {
        rb = GetComponent<Rigidbody2D>();
        selected = false;
	}
	
	void Update () {

        if (tilt == false)
        {
            if (selected == false)
            {
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);

                    pointToMove = Camera.main.ScreenToWorldPoint(touch.position);
                }

                transform.position = Vector2.MoveTowards(transform.position, pointToMove, movementSpeed * Time.deltaTime);
            }
            else {
                if (Vector3.Distance(transform.position, SelectedSite.transform.position) > 0.1f)
                {
                    transform.position = Vector2.MoveTowards(transform.position, SelectedSite.transform.position, movementSpeed * Time.deltaTime);
                }
                else {
                    SelectedSite.GetComponent<Site_Info>().LoadCorrespondingScene();
                }
            }
            
        }
        else {
            if (selected == false) {
                dirX = Input.acceleration.x * movementSpeed;
                dirY = Input.acceleration.y * movementSpeed;
            }
        }

    }

    void FixedUpdate()
    {
        if (tilt == true) {
            if (selected == false) {
                rb.velocity = new Vector2(dirX, dirY);
            }
        }
    }


    public void MoveToClosestSite() {
        selected = true;
        SelectedSite = GetComponent<Site_Finder>().closestSite;
    } 
}
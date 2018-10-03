using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest_Touch_Manager : MonoBehaviour {

	public Vector2 lookPosition;

	public Transform WindTrans;
	
	// Use this for initialization
	void Start () {
		
		
		
	}
	
	// Update is called once per frame
	void Update() {
		for (int i = 0; i < Input.touchCount; ++i) {
			if (Input.GetTouch(i).phase == TouchPhase.Began) {
				//clone = Instantiate(projectile, transform.position, transform.rotation) as GameObject;

				lookPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);

				
				WindTrans.LookAt(lookPosition);

			}
		}
	}
}

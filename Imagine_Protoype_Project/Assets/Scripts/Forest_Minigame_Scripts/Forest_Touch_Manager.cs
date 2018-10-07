using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest_Touch_Manager : MonoBehaviour {

	 Vector2 lookPosition;

	public Transform WindTrans;

	public GameObject TrailPrefab;

	private GameObject _thisTrail;
	private TrailRenderer _trailRenderer;

	private Vector3 _startPos;

	private Plane _objPlane;

	public Transform Wind;
	
	
	
	// Use this for initialization
	void Start () {
		
		_objPlane = new Plane(Camera.main.transform.forward * -1, transform.position);
		
		
	}
	
	// Update is called once per frame
	void Update() {
		
		
		
		
		//for (int i = 0; i < Input.touchCount; ++i) {
		if (Input.touchCount > 0) {

			if (Input.GetTouch(0).phase == TouchPhase.Began) {

				Vector2 TrailPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

				_thisTrail = Instantiate(TrailPrefab, TrailPos, Quaternion.identity);

				_trailRenderer = _thisTrail.GetComponent<TrailRenderer>();

				//		Ray mRay = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

				//float rayDistance;

				//			if (_objPlane.Raycast(mRay, out rayDistance)) {

				//		_startPos = mRay.GetPoint(rayDistance);

				//	}




				//clone = Instantiate(projectile, transform.position, transform.rotation) as GameObject;

				//	lookPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);


				//WindTrans.LookAt(lookPosition);

			} else if (Input.GetTouch(0).phase == TouchPhase.Moved) {

				//	Ray mRay = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);


				//		float rayDistance;

				//		if (_objPlane.Raycast(mRay, out rayDistance)) {

				Vector2 TrailPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

				_thisTrail.transform.position = TrailPos; //mRay.GetPoint(rayDistance);

				//}


			} else if (Input.GetTouch(0).phase == TouchPhase.Ended) {

				//Destroy(_thisTrail, );

				_thisTrail.GetComponent<TrailRenderer>().time = 0.5f;
				Destroy(_thisTrail, 0.5f);


			}


		}


		if (_thisTrail != null && _trailRenderer != null) {

			
			Wind.gameObject.SetActive(true);
			Wind.position = _trailRenderer.GetPosition(0);

			if (_trailRenderer.positionCount > 1) {
				Wind.LookAt(_trailRenderer.GetPosition(1));
			}


		} else {

			Wind.gameObject.SetActive(false);
			
		}


	}

//	}
}

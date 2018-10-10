using UnityEngine;


public class Forest_Touch_Manager : MonoBehaviour {

     private Plane _objPlane;

     private Vector3 _startPos;

     private GameObject    _thisTrail;
     private TrailRenderer _trailRenderer;

     private Vector2 lookPosition;

     //public Transform WindTrans;

     private WindZone _windZone;

     public float WindStrength = 10f; 
     
     public GameObject TrailPrefab;

     public Transform Wind;


     // Use this for initialization
     private void Start() {

          _objPlane = new Plane(Camera.main.transform.forward * -1, transform.position);

          _windZone = Wind.GetComponentInChildren<WindZone>();


     }

     // Update is called once per frame
     private void Update() {


          //for (int i = 0; i < Input.touchCount; ++i) {
          if (Input.touchCount > 0) {

               if (Input.GetTouch(0).phase == TouchPhase.Began) {

                    Vector2 TrailPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

                    _thisTrail = Instantiate(TrailPrefab, TrailPos, Quaternion.identity);

                    _trailRenderer = _thisTrail.GetComponent<TrailRenderer>();
                    
                    
                    
                    //AudioManager.Master.Play("Wind");

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

               if (_trailRenderer.positionCount > 0) Wind.position = _trailRenderer.GetPosition(0);

               if (_trailRenderer.positionCount > 1) {
                    Wind.LookAt(_trailRenderer.GetPosition(1));

                    float strength = Vector2.Distance(_trailRenderer.GetPosition(0), _trailRenderer.GetPosition(1));
                   // Debug.Log(strength);

                    strength *= WindStrength;


                    _windZone.windMain = strength;
                    
                    
                    Handheld.Vibrate();


               }


          } else {

               Wind.gameObject.SetActive(false);

              
               

          }


     }

//	}
}
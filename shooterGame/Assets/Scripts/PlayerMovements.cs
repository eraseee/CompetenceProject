using UnityEngine;
using System.Collections;

public class PlayerMovements : MonoBehaviour{

	//public float Verticalspeed = 10.0F;
	public float Horizontalspeed = 10.0F;
	public float jumpSpeed = 1.0f;
	public Rigidbody rocket;
	public float speed = 10.0f;

	Rigidbody bullet;

//	float GroundDistance = 0;
	Rigidbody rig;
	RaycastHit hit;
	CapsuleCollider caps;
	float distToGround;

	Vector3 shootDirection;


	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody>();
		caps = GetComponent<CapsuleCollider>();
		distToGround = caps.bounds.extents.y;
		Debug.Log(distToGround);
//		rocket = Resources.Load("Rocket") as GameObject;
	}


	// Update is called once per frame
	void Update() {
		//float VerticalTranslation = Input.GetAxis("Vertical") * Verticalspeed;
		//VerticalTranslation *= Time.deltaTime;
		//rig.AddForce(Vector3.up * VerticalTranslation);
		//transform.Translate(0, VerticalTranslation, 0);
		if(isGrounded() && Input.GetKey("w") || isGrounded() && Input.GetKey("up")){
			jump();
		}

		if(Input.GetMouseButtonDown(0)){
			shoot();
		}

		float HorizontalTranslation = Input.GetAxis("Horizontal") * Horizontalspeed;
		HorizontalTranslation *= Time.deltaTime;
		transform.Translate(HorizontalTranslation, 0, 0);
	}

	bool isGrounded() {
		return Physics.Raycast(rig.position, -Vector3.up, GetComponent<CapsuleCollider>().bounds.extents.y + 0.1f);
		//return true;
	}

	void jump() {
		rig.AddForce(Vector3.up * jumpSpeed, ForceMode.VelocityChange);
	}

	void shoot() {
		shootDirection = Input.mousePosition;
		shootDirection.z = 0.0f;
		shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
		shootDirection = shootDirection-transform.position;
		bullet = Instantiate (rocket, transform.position,
		                      Quaternion.identity) as Rigidbody;
		//bullet.GetComponent<Rigidbody>().velocity = new Vector3(shootDirection.x * speed, shootDirection.y * speed, 0);
		bullet.velocity = transform.TransformDirection(shootDirection * speed);
	}

}

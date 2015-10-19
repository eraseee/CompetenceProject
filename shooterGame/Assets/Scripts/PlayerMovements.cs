using UnityEngine;
using System.Collections;

public class PlayerMovements : MonoBehaviour{

	public float Horizontalspeed = 10.0F;
	public float jumpSpeed = 1.0f;
	// public Rigidbody rocket;
	// public float speed = 10.0f;
	// 
	// Rigidbody bullet;

	Rigidbody rig;
	RaycastHit hit;
	CapsuleCollider caps;
	float distToGround;
	// bool canShoot;
	// bool machineGunUnlocked;
	bool canJump;

	// Vector3 shootDirection;


	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody>();
		caps = GetComponent<CapsuleCollider>();
		distToGround = caps.bounds.extents.y;
		// canShoot = true;
		canJump = true;
	}


	void FixedUpdate() {
		if(isGrounded() && Input.GetKey("w") && canJump || isGrounded() && Input.GetKey("up") && canJump){
			// rig.velocity = new vector3(0,0,0);
			StartCoroutine("jumping");
		}
	}

	// Update is called once per frame
	void Update() {
		// if(isGrounded() && Input.GetKey("w") || isGrounded() && Input.GetKey("up")){
		// 	rig.velocity = new vector3(0,0,0);
		// 	jump();
		// }

		// if(Input.GetMouseButton(0) && canShoot && machineGunUnlocked){
		// 	StartCoroutine("machineGun");
		// }
		// else if(Input.GetMouseButton(0) && canShoot) {
		// 	StartCoroutine("gunShot");
		// }

		float HorizontalTranslation = Input.GetAxis("Horizontal") * Horizontalspeed;
		HorizontalTranslation *= Time.deltaTime;
		transform.Translate(HorizontalTranslation, 0, 0);
	}

	bool isGrounded() {
		return Physics.Raycast(rig.position, -Vector3.up, caps.bounds.extents.y + 0.1f);
	}

	void jump() {
		rig.AddForce(Vector3.up * jumpSpeed, ForceMode.VelocityChange);
	}


	IEnumerator jumping() {
		canJump = false;
		jump();
		yield return new WaitForSeconds(0.5f);
		canJump = true;
	}

	// void shoot(Rigidbody bullet) {
	// 	shootDirection = Input.mousePosition;
	// 	shootDirection.z = 0.0f;
	// 	shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
	// 	shootDirection = shootDirection-transform.position;
	// 	bullet.velocity = transform.TransformDirection(shootDirection * speed);
	// 	Physics.IgnoreCollision(bullet.GetComponent<collider>(), caps);
	// }
	// 
	// 
	// IEnumerator gunShot() {
	// 	canShoot = false;
	// 	bullet = Instantiate (rocket, transform.position,
	// 												Quaternion.identity) as Rigidbody;
	// 	shoot(bullet);
	// 	yield return new WaitForSeconds(0.5f);
	// 	Destroy(bullet.gameObject);
	// 	canShoot = true;
	// }
	// 
	// IEnumerator machineGun() {
	// 	canShoot = false;
	// 	bullet = Instantiate (rocket, transform.position,
	// 												Quaternion.identity) as Rigidbody;
	// 	shoot(bullet);
	// 	yield return new WaitForSeconds(0.05f);
	// 	Destroy(bullet.gameObject);
	// 	canShoot = true;
	// }
}

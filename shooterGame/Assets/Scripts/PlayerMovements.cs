using UnityEngine;
using System.Collections;

public class PlayerMovements : MonoBehaviour{

	public float Horizontalspeed = 10.0F;
	public float jumpSpeed;

	Rigidbody rig;
	RaycastHit hit;
	CapsuleCollider caps;
	float distToGround;
	bool canJump;



	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody>();
		caps = GetComponent<CapsuleCollider>();
		distToGround = caps.bounds.extents.y;
		canJump = true;
	}


	void FixedUpdate() {
		if(isGrounded() && Input.GetKey("w") && canJump || isGrounded() && Input.GetKey("up") && canJump){
			StartCoroutine("jumping");
		}
	}

	// Update is called once per frame
	void Update() {
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


}

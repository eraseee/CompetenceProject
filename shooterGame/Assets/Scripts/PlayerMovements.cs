using UnityEngine;
using System.Collections;

public class PlayerMovements : MonoBehaviour{

	public float Horizontalspeed = 10.0F;
	public float jumpSpeed;

	Rigidbody rig;
	RaycastHit hit;
	CapsuleCollider caps;
	JumpPowerUp JumpPowerUp;
	bool canJump;
	bool JumpPower;


	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody>();
		caps = GetComponent<CapsuleCollider>();
		canJump = true;
		JumpPower = false;
		JumpPowerUp = GameObject.Find("Player").GetComponent<JumpPowerUp>();
	}


	void FixedUpdate() {
		if(isGrounded() && Input.GetKey("w") && canJump || isGrounded() && Input.GetKey("up") && canJump){
			StartCoroutine("jumping");
		}
	}

	// Update is called once per frame
	void Update() {
		JumpPower = JumpPowerUp.GetJumpUnlock();
		float HorizontalTranslation = Input.GetAxis("Horizontal") * Horizontalspeed;
		HorizontalTranslation *= Time.deltaTime;
		transform.Translate(HorizontalTranslation, 0, 0);
	}

	bool isGrounded() {
		return Physics.Raycast(rig.position, -Vector3.up, caps.bounds.extents.y + 0.1f);
	}

	void jump(float jumpHeight) {
		Debug.Log("jumpHeight = " + jumpHeight);
		rig.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
	}


	IEnumerator jumping() {
		Debug.Log("Do i enter jumping");
		canJump = false;
		if(JumpPower){
		jump(jumpSpeed * 2);
		} else jump(jumpSpeed);
		yield return new WaitForSeconds(0.5f);
		canJump = true;
	}
}

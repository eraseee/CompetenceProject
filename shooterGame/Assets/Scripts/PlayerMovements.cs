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

	Vector3 lookingAt;

	Vector3 mousePos;
	Vector3 objectPos;
	public Transform target;
	float angle;


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
		// lookingAt = Input.mousePosition;
		// lookingAt = Camera.main.ScreenToWorldPoint(lookingAt);
		// lookingAt = lookingAt - transform.position;
		// float angle = Mathf.Atan2(lookingAt.z, lookingAt.y) * Mathf.Rad2Deg;
		// transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		// mousePos = Input.mousePosition;
		// mousePos.z = 10;
		// objectPos = Camera.main.WorldToScreenPoint(target.position);;
		// mousePos.x = mousePos.x - objectPos.x;
		// mousePos.y = mousePos.y - objectPos.y;
		// angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		// transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
		// 


		JumpPower = JumpPowerUp.GetJumpUnlock();
		float HorizontalTranslation = Input.GetAxis("Horizontal") * Horizontalspeed;
		HorizontalTranslation *= Time.deltaTime;
		transform.Translate(HorizontalTranslation, 0, 0);
	}

	bool isGrounded() {
		return Physics.Raycast(rig.position, -Vector3.up, caps.bounds.extents.y + 0.1f);
	}

	void jump(float jumpHeight) {
		rig.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
	}


	IEnumerator jumping() {
		canJump = false;
		if(JumpPower){
		jump(jumpSpeed * 2);
		} else jump(jumpSpeed);
		yield return new WaitForSeconds(0.5f);
		canJump = true;
	}
}

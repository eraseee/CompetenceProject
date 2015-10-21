using UnityEngine;
using System.Collections;

public class JumpPowerUp : MonoBehaviour {
	bool jumpUnlocked;

	GameObject jumpPower;
	GameObject player;

	BoxCollider powerCollider;

	// Use this for initialization
	void Start () {
		jumpUnlocked = false;
		jumpPower = GameObject.FindWithTag("JumpPower");
		player = GameObject.Find("Player");
	}


	void OnTriggerEnter(Collider JumpCollider) {
		if(JumpCollider.gameObject.tag == "JumpPower"){
			StartCoroutine("JumpPower");
			Destroy(jumpPower);
		}
	}

	// Update is called once per frame
	void Update () {

	}

	public bool GetJumpUnlock () {
		return jumpUnlocked;
	}

	void setJumpPower (bool mac) {
		jumpUnlocked = mac;
	}

	IEnumerator JumpPower() {
		setJumpPower(true);
		yield return new WaitForSeconds(10.0f);
		setJumpPower(false);
	}
}

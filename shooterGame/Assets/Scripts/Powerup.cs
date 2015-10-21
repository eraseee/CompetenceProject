using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

	bool machineGunUnlocked;

	GameObject powerUp;
	GameObject player;

	BoxCollider powerCollider;

	// Use this for initialization
	void Start () {
		machineGunUnlocked = false;
		powerUp = GameObject.FindWithTag("PowerUp");
	}


	void OnTriggerEnter(Collider powerCollider) {
		if(powerCollider.gameObject.tag == "PowerUp"){
			StartCoroutine("MachineGunPower");
			Destroy(powerUp);
		}
	}

	// Update is called once per frame
	void Update () {

	}


	public bool GetMachineGun () {
		return machineGunUnlocked;
	}

	void setMachineGun (bool mac) {
		machineGunUnlocked = mac;
	}

	IEnumerator MachineGunPower() {
		setMachineGun(true);
		yield return new WaitForSeconds(10.0f);
		setMachineGun(false);
	}

}

using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

	bool machineGunUnlocked;

	GameObject powerUp;
	GameObject player;
	Renderer rend;

	BoxCollider powerCollider;

	// Use this for initialization
	void Start () {
		machineGunUnlocked = false;
		powerUp = GameObject.FindWithTag("PowerUp");
		player = GameObject.Find("Player");
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
		rend = player.GetComponent<Renderer>();
		rend.material.SetColor("_Color", Color.green);
		yield return new WaitForSeconds(10.0f);
		rend.material.SetColor("_Color", Color.blue);
		setMachineGun(false);
	}

}

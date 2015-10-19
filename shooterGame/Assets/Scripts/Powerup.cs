using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

	bool machineGunUnlocked;

	GameObject powerup;

	// Use this for initialization
	void Start () {
		machineGunUnlocked = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public bool GetMachineGun () {
		return machineGunUnlocked;
	}
}

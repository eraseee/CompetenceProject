using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public GameObject rocket;
	public float speed = 10.0f;

	GameObject bullet;
	GameObject invis;
	GameObject returnBullet;

	bool canShoot;
	bool machineGunUnlocked;
	bool shotFired;
	bool destroyShot;

	Vector3 shootDirection;
	Ray lookingAt;

	Vector3 lookTarget;

	Powerup powerup;

	RaycastHit hit;

	// Use this for initialization
	void Start () {
		shotFired = false;
		canShoot = true;
		machineGunUnlocked = false;
		powerup = GameObject.Find("Player").GetComponent<Powerup>();
	}


	// Update is called once per frame
	void Update () {

		machineGunUnlocked = powerup.GetMachineGun();

		if(Input.GetMouseButton(0) && canShoot && machineGunUnlocked){
			StartCoroutine("machineGun");
		}
		else if(Input.GetMouseButton(0) && canShoot) {
			StartCoroutine("gunShot");
		}
		if(shotFired) {
		    {
		        if (returnBullet != null)
		        {
                    returnBullet.transform.Translate(shootDirection * Time.deltaTime * speed);
                }

		    }
		}
	}

	GameObject shoot(GameObject bullet) {
		shotFired = true;
		shootDirection = Input.mousePosition;
		shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
		shootDirection.z = 0.0f;
		shootDirection = shootDirection-transform.position;
		returnBullet = bullet;
		return returnBullet;
	}


	IEnumerator gunShot() {
		canShoot = false;
		bullet = Instantiate (rocket, transform.position,
													Quaternion.identity) as GameObject;
		shoot(bullet);
		yield return new WaitForSeconds(0.5f);
		shotFired = false;
		Destroy(bullet);
		canShoot = true;
	}

	IEnumerator machineGun() {
		canShoot = false;
		bullet = Instantiate (rocket, transform.position,
													Quaternion.identity) as GameObject;
		GameObject Shots = shoot(bullet);
		yield return new WaitForSeconds(0.25f);
		canShoot = true;
		yield return new WaitForSeconds(0.25f);
		shotFired = false;
		Destroy(Shots);
	}
}

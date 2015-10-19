using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public Rigidbody rocket;
	public float speed = 10.0f;

	Rigidbody bullet;

	bool canShoot;
	bool machineGunUnlocked;

	Vector3 shootDirection;



	// Use this for initialization
	void Start () {
		canShoot = true;
		machineGunUnlocked = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetMouseButton(0) && canShoot && machineGunUnlocked){
			StartCoroutine("machineGun");
		}
		else if(Input.GetMouseButton(0) && canShoot) {
			StartCoroutine("gunShot");
		}

	}

	void shoot(Rigidbody bullet) {
		shootDirection = Input.mousePosition;
		shootDirection.z = 0.0f;
		shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
		shootDirection = shootDirection-transform.position;
		bullet.velocity = transform.TransformDirection(shootDirection * speed);
		//Physics.IgnoreCollision(bullet.GetComponent<collider>(), caps);
	}


	IEnumerator gunShot() {
		canShoot = false;
		bullet = Instantiate (rocket, transform.position,
													Quaternion.identity) as Rigidbody;
		shoot(bullet);
		yield return new WaitForSeconds(0.5f);
		Destroy(bullet.gameObject);
		canShoot = true;
	}

	IEnumerator machineGun() {
		canShoot = false;
		bullet = Instantiate (rocket, transform.position,
													Quaternion.identity) as Rigidbody;
		shoot(bullet);
		yield return new WaitForSeconds(0.05f);
		Destroy(bullet.gameObject);
		canShoot = true;
	}
}

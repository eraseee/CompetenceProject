using UnityEngine;
using System.Collections;

public class DestroyBulletOnHit : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{

	}

	void OnCollisionEnter(Collision Other) {
			Debug.Log("AM I STIlL HITTING??");
			Destroy(this.gameObject);
	}

    // Update is called once per frame
    void Update ()
	{

	}
}

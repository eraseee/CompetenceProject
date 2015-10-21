using UnityEngine;
using System.Collections;

public class DestroyBulletOnHit : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{

	}

	void OnCollisionEnter(Collision Other) {
			Destroy(this.gameObject);
	}

    void OnTriggerEnter(Collider col)
    {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update ()
	{

	}
}

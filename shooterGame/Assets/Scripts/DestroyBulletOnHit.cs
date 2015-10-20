using UnityEngine;
using System.Collections;

public class DestroyBulletOnHit : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}

	void OnCollisionEnter(Collision Other) {
		if (Other.gameObject != null) {
			Debug.Log("SUP NIGGUH YOU HIT SOMETHING");
		}
	}

	
	// Update is called once per frame
	void Update ()
	{
	
	}
}


using UnityEngine;
using System.Collections;

public class FallingObstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
}

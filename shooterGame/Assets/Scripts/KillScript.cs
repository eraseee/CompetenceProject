using UnityEngine;
using System.Collections;

public class KillScript : MonoBehaviour
{
    private Vector3 startPos;

	// Use this for initialization
	void Start ()
	{
	    startPos = transform.position;

	}
	
	// Update is called once per frame
	void Update ()
    {

	    if (transform.position.y < -10)
	    {
            transform.position = startPos;
	    }
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            transform.position = startPos;
        }
    

    }
}

using UnityEngine;
using System.Collections;

public class KillScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
    {

	    if (transform.position.y < -10)
	    {
            Application.LoadLevel(Application.loadedLevel);
        }
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "RollingObstacle")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    

    }
}

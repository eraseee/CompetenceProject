using UnityEngine;
using System.Collections;

public class KillScript : MonoBehaviour
{
    private CapsuleCollider caps;

	// Use this for initialization
	void Start ()
	{
        caps = GetComponent<CapsuleCollider>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {

	    if (Physics.Raycast(transform.position, Vector3.up, caps.bounds.extents.y + 0.1f))
	    {
            Application.LoadLevel(Application.loadedLevel);
        }

    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "KillingObstacle" || collision.gameObject.tag == "DeathTrigger")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
   
    }
}

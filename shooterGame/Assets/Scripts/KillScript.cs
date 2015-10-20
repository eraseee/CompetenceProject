using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KillScript : MonoBehaviour
{
    private CapsuleCollider caps;
    public Text text;
    private int timeToComplete = 200;

	// Use this for initialization
	void Start ()
	{
        caps = GetComponent<CapsuleCollider>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
	{
        int secondsPlayed = (int) (Time.time % 60);
	    text.text = "Time left: " + (timeToComplete - secondsPlayed);

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

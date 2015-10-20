using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KillScript : MonoBehaviour
{
    private CapsuleCollider caps;
    public Text text;
    public int timeToComplete = 100;

	// Use this for initialization
	void Start ()
	{
        caps = GetComponent<CapsuleCollider>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
	{
        int secondsPlayed = (int) (Time.timeSinceLevelLoad % 60);
	    int time = (timeToComplete - secondsPlayed);

	    if (time == 0)
	    {
            Application.LoadLevel(Application.loadedLevel);
        }

        text.text = "Time left: " + time;

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

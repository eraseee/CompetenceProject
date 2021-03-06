﻿using UnityEngine;
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
        int secondsPlayed =  Mathf.RoundToInt(Time.timeSinceLevelLoad);
	    int time = (timeToComplete - secondsPlayed);

	    if (time == 0)
	    {
            Application.LoadLevel(Application.loadedLevel);
        }

        text.text = "Time left: " + time;
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "KillingObstacle" || col.gameObject.tag == "DeathTrigger")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

}

using UnityEngine;
using System.Collections;

public class GoalLine : MonoBehaviour
{


    private GameObject player;

	// Use this for initialization
	void Start () {


        player = GameObject.Find("Player");
	    

        foreach (Transform child in this.transform)
        {
            child.GetComponent<ParticleSystem>().Stop();
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        foreach (Transform child in this.transform)
        {
            child.GetComponent<ParticleSystem>().Play();
        }

        player.GetComponent<PlayerMovements>().enabled = false;
        player.GetComponent<KillScript>().enabled = false;
      //  player.GetComponent<Shooting>().enabled = false;

    }

}

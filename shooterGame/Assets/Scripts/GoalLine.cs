using UnityEngine;
using System.Collections;
using UnityEngine.Networking.Match;

public class GoalLine : MonoBehaviour
{


    private GameObject player;
    private AudioSource backAudioSource;

    public AudioSource[] AudioSources;

	// Use this for initialization
	void Start ()
	{
	    backAudioSource = Camera.main.GetComponent<AudioSource>();
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

        StartCoroutine("FireWorksSound");
    }

    IEnumerator FireWorksSound()
    {

        AudioSources[0].Play();

        int i = 0;
        backAudioSource.Stop();
        while (i <= 100)
        {
            i++;
            yield return new WaitForSeconds(1);
            AudioSources[1].Play();

        }
    }




}

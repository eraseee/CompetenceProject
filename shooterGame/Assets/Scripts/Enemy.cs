using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    
    public Transform target;
    NavMeshAgent agent;
	// Use this for initialization
	void Start () {

        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (agent.remainingDistance == 0) {
            Debug.Log("hello");
            target.position = new Vector3(target.position.x - Random.Range(-10.0f, 10.0f), target.position.y, target.position.z);
            agent.SetDestination(target.position);
           
            }
	}
}

using UnityEngine;
using System.Collections;

public class RollingObstacle : MonoBehaviour {

    private Vector3 rightPos;
    private Vector3 leftPos;



    // Use this for initialization
    void Start () {
        rightPos = this.transform.position;
        leftPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
       // yield return StartCoroutine("MoveObjectDown");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

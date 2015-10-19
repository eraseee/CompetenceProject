using UnityEngine;
using System.Collections;

public class UpDownObject : MonoBehaviour {

    private Vector3 upPos;
    private Vector3 downPos;



    // Use this for initialization
    IEnumerator Start ()
    {
        upPos = this.transform.position;
        downPos = new Vector3(this.transform.position.x, 27.20f, this.transform.position.z);
        yield return StartCoroutine("MoveObjectDown");
      

    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    IEnumerator MoveObjectDown()
    {
        float randomWaitSeconds = Random.Range(1f, 2F);

        // suspend execution for 2 seconds
        yield return new WaitForSeconds(randomWaitSeconds);

        float elapsedTime = 0;
        while (elapsedTime <= 0.5f)
        {
            float moveA = elapsedTime * 5;
            transform.position = Vector3.Lerp(upPos, downPos, moveA);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return StartCoroutine("MoveObjectUp");
    }

    IEnumerator MoveObjectUp()
    {
        // suspend execution for 2 seconds
        yield return new WaitForSeconds(2);

        float elapsedTime = 0;
        while (elapsedTime <= 3f)
        {
            float moveA = elapsedTime * 2;
            transform.position = Vector3.Lerp(downPos, upPos, moveA);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return StartCoroutine("MoveObjectDown");
    }



}

﻿using UnityEngine;
using System.Collections;

public class RollingObstacle : MonoBehaviour {

    private Vector3 rightPos;
    private Vector3 leftPos;

    // Use this for initialization
    IEnumerator Start () {
        rightPos = this.transform.position;
        leftPos = new Vector3(this.transform.position.x - 7, this.transform.position.y, this.transform.position.z);
         yield return StartCoroutine("MoveObjectLeft");
    }

    // Update is called once per frame
    void Update ()
    {

	
	}

    IEnumerator MoveObjectLeft()
    {

        float randomWaitSeconds = Random.Range(1f, 2F);
        // suspend execution for x seconds
        yield return new WaitForSeconds(randomWaitSeconds);

        float elapsedTime = 0;
        while (elapsedTime <= 3f)
        {

            float moveA = elapsedTime * 1.5f;
            transform.position = Vector3.Lerp(rightPos, leftPos, moveA);
            transform.Rotate(Vector3.up * Time.deltaTime * 10);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        yield return StartCoroutine("MoveObjectRight");
    }

    IEnumerator MoveObjectRight()
    {

        float randomWaitSeconds = Random.Range(1f, 2F);
        // suspend execution for x seconds
        yield return new WaitForSeconds(randomWaitSeconds);

        float elapsedTime = 0;
        while (elapsedTime <= 3f)
        {
            float moveA = elapsedTime * 1.5f;
            transform.position = Vector3.Lerp(leftPos, rightPos, moveA);
            transform.Rotate(-Vector3.up * Time.deltaTime * 10);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        yield return StartCoroutine("MoveObjectLeft");
    }
}

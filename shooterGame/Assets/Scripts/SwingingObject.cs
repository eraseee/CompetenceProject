﻿using UnityEngine;
using System.Collections;

public class SwingingObject : MonoBehaviour
{

    public float Speed = 2f;
    public Quaternion startRotation;
    public float RotateAmount = 45f;


    // Use this for initialization
    void Start () {
        startRotation = transform.rotation;

    }
	
	// Update is called once per frame
	void Update () {

        transform.rotation = Quaternion.AngleAxis(RotateAmount * Mathf.Sin(Time.time * Speed), Vector3.forward) * startRotation;
    }
}

using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float Verticalspeed = 10.0F;
	public float Horizontalspeed = 10.0F;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame

	void Update() {
			float VerticalTranslation = Input.GetAxis("Vertical") * Verticalspeed;
			float HorizontalTranslation = Input.GetAxis("Horizontal") * Horizontalspeed;
			VerticalTranslation *= Time.deltaTime;
			HorizontalTranslation *= Time.deltaTime;
			transform.Translate(HorizontalTranslation, 0, 0);
			transform.Translate(0, VerticalTranslation, 0);
	}
}

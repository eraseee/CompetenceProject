using UnityEngine;
using System.Collections;

public class ElevatorMovement : MonoBehaviour
{

    public float speed;


    // Use this for initialization
    private void Start()
    {
       
    }

    // Update is called once per frame
    private void Update()
    {
       
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
        if (transform.position.y < -8.5)
        {
            Debug.Log(transform.position.y);

            transform.Translate(speed * Vector3.up * Time.deltaTime);
        }
    }

   
}

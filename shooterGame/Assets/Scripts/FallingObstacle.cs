using UnityEngine;
using System.Collections;

public class FallingObstacle : MonoBehaviour {



    public float Speed;
    public Quaternion startRotation;
    public float RotateAmount;
    public bool isShaking = false;

    private Transform parent;
  
    // Use this for initialization
    void Awake () {
        parent = this.transform.parent;
        startRotation = parent.rotation;
   
    }

    // Update is called once per frame
    void Update () {
        if (isShaking)
        {
            parent.rotation = Quaternion.AngleAxis(RotateAmount * Mathf.Sin(Time.time * Speed), Vector3.forward) * startRotation;
        }
    

    }


    IEnumerator MakeObjectFall()
    {


        isShaking = true;
        // suspend execution for 3 seconds
        yield return new WaitForSeconds(2);
        isShaking = false;
        parent.GetComponent<Rigidbody>().isKinematic = false;
    }

    IEnumerator OnTriggerEnter(Collider col)
    {
        yield return StartCoroutine("MakeObjectFall");
    }

}

using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour
{

    public int life;
    public GameObject hitExplosion;
    public GameObject deadExplosion;
    private SphereCollider sphereCollider;


    // Use this for initialization
    void Start ()
    {

        sphereCollider = this.GetComponent<SphereCollider>();

  
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    private void OnTriggerEnter(Collider col)
    {


        if (col.gameObject.tag == "Bullet")
        {

            life--;
            if (life > 0)
            {
                Instantiate(hitExplosion, new Vector3(this.transform.position.x, this.transform.position.y, -5), Quaternion.identity);
            }
            else
            {
                Instantiate(deadExplosion, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }


}

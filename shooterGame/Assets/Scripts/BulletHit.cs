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


    private void OnCollisionEnter(Collision collisionInfo)
    {


        if (collisionInfo.gameObject.tag == "Bullet")
        {

            life--;
            if (life > 0)
            {
                Instantiate(hitExplosion, this.transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(deadExplosion, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }


}

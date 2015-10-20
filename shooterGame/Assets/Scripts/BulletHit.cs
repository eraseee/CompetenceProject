using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour
{

    public int life;
    public GameObject hitExplosion;
    public GameObject deadExplosion;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    private void OnCollisionEnter(Collision collisionInfo)
    {


        if (collisionInfo.gameObject.tag == "Bullet")
        {
            //Destroy(collisionInfo.gameObject);
            collisionInfo.gameObject.SetActive(false);

            life--;
            if (life > 0)
            {
                GameObject fire = Instantiate(hitExplosion, this.transform.position, Quaternion.identity) as GameObject;
                fire.transform.parent = this.transform;
                fire.transform.localPosition = new Vector3(0, 1.2f, -1f);
            }
            else
            {
                Instantiate(deadExplosion, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }


}

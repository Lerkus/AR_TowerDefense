using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NozzleController : MonoBehaviour {
    private ParticleSystem ps;
    public Rigidbody bullet;
    public float speed;
	// Use this for initialization
	void Start () {
        ps = GetComponentInChildren<ParticleSystem>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Shoot()
    {
        Rigidbody newBullet = Instantiate(bullet,gameObject.transform.position,gameObject.transform.rotation,null);
        newBullet.AddForce(this.transform.forward.normalized * speed);
        ps.Play();
    }
}

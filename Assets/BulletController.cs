using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public int Damage;
    public float lifetime;
	// Use this for initialization
	void Start () {
        Object.Destroy(gameObject, lifetime);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Creep")
        {
            other.GetComponent<CreepController>().Hitpoints -= Damage;
            Debug.Log("Hit");
            GameObject.Destroy(gameObject);
            
        }
    }

}

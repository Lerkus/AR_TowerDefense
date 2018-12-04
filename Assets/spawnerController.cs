using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerController : MonoBehaviour {


    public float frequency;
    public Rigidbody creep;
    public bool spawning;
    private float lastSpawn;
	// Use this for initialization
	void Start () {
        lastSpawn = 0;
	}
	
	// Update is called once per frame
	void Update () {


        if (spawning && (lastSpawn + frequency) < Time.time)
        {
            lastSpawn = Time.time;
            Spawn();
        }
    }

    private void Spawn()
    {
        Instantiate(creep, gameObject.transform.position, gameObject.transform.rotation, null);
    }
}

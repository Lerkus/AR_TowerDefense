using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrelController : MonoBehaviour {
    private NozzleController nozzle;

	// Use this for initialization
	void Start () {
        nozzle = GetComponentInChildren<NozzleController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Shoot()
    {
        nozzle.Shoot();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretController : MonoBehaviour {
    private bool shooting = false;
    private barrelController[] barrels;
    private int NextBarrel = 0;
    private float lastShot = 0;
    public float firerate;


    public GameObject Target;
	// Use this for initialization
	void Start () {
        barrels = GetComponentsInChildren<barrelController>();
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.LookAt(Target.transform);

        if (shooting && (lastShot + firerate)<Time.time)
        {
            Shoot();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}

    private void Shoot()
    {
        lastShot += firerate;
        barrels[NextBarrel].Shoot();
        NextBarrel++;
        if (NextBarrel >= barrels.Length)
        {
            NextBarrel = 0;
        }
    }

    public void StartShooting()
    {
        shooting = true;
    }
    public void StopShooting()
    {
        shooting = false;
    }
}

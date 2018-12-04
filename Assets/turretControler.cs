using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {
    private bool shooting = true;
    private barrelController[] barrels;
    private int NextBarrel = 0;
    private float lastShot = 0;
    public float firerate;
    public bool useGravityCompensation;
    public float compesationAngle;


    private GameObject Target;
	// Use this for initialization
	void Start () {
        barrels = GetComponentsInChildren<barrelController>();
    }
	
	// Update is called once per frame
	void Update () {
        


        try
        {
            
            //TODO: calculate compensationAngle
            if (useGravityCompensation)
            {
                gameObject.transform.LookAt(Target.transform.position);
                gameObject.transform.Rotate(-compesationAngle, 0, 0);
            }
            else
            {
                gameObject.transform.LookAt(Target.transform.position);
            }
            
        } catch(Exception ex) {
            if (ex is NullReferenceException || ex is MissingReferenceException)
            {
                if (GameObject.FindGameObjectsWithTag("Creep").Length == 0)
                {
                    StopShooting();
                }
                else
                {
                    Target = GameObject.FindGameObjectsWithTag("Creep")[0];
                    StartShooting();
                }
            }
           
               

        }
        
           

        

        if (shooting && (lastShot + firerate)<Time.time)
        {
            lastShot = Time.time;
            Shoot();
        }

	}

    private void Shoot()
    {
        Debug.Log("firerig Barrel" + NextBarrel);
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {
    private bool shooting = false;
    private bool shouldShoot = false;
    private barrelController[] barrels;
    private int NextBarrel = 0;
    private float lastShot = 0;
    public float firerate;
    public bool useGravityCompensation;
    public float compesationAngle;
    private List<GameObject> possTargets = new List<GameObject>();

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

        }
        catch (Exception ex)
        {
            if (ex is NullReferenceException || ex is MissingReferenceException || ex is UnassignedReferenceException )
            {
                try
                {
                    possTargets.Remove(Target.gameObject);
                }
                catch
                {

                }
                
                getNewTarget();
            }
           

        }
        if (Target != null && shouldShoot)
        {
            shooting = true;
        }
        else
        {
            shooting = false;
        }
        




        if (shooting && (lastShot + firerate) < Time.time)
        {
            lastShot = Time.time;
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
        shouldShoot = true;
    }
    public void StopShooting()
    {
        shouldShoot = false;
    }


    private void getNewTarget()
    {
        if(possTargets.Count > 1)
            Target = possTargets[0];
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Creep")
        {
            possTargets.Remove(other.gameObject);
            if (other.gameObject == Target)
            {
                getNewTarget();
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Creep")
        {
            possTargets.Add(other.gameObject);
        }
    }
}

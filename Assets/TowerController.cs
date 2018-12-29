using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

    public GameObject landingpad;
    public float positionalTolerance;
    private BaseController baseC;
    private TurretController turret;


    // Use this for initialization
    void Start () {
       
		 baseC = GetComponentInChildren<BaseController>();
        turret = GetComponentInChildren<TurretController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position, landingpad.transform.position) > positionalTolerance)
        {
            baseC.moveTo(landingpad.transform.position);
        }





        if(baseC.currentFlightStatus == BaseController.flightstatus.landed)
        {
            turret.StartShooting();
            Debug.Log("landed");
        }
        else
        {
            turret.StopShooting();
        }
       
    }

}

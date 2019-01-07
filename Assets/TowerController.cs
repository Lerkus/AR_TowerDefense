using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TowerController : MonoBehaviour , ITrackableEventHandler{

    public GameObject landingpad;
    public float positionalTolerance;
    private BaseController baseC;
    private TurretController turret;




    private bool firstDect = false;
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else
        {
            OnTrackingLost();
        }
    }

    private void OnTrackingLost()
    {
       
    }

    private void OnTrackingFound()
    {
        firstDect = true;
        gameObject.transform.position = landingpad.gameObject.transform.position;
    }




    // Use this for initialization
    void Start () {
       landingpad.GetComponent<TrackableBehaviour>().RegisterTrackableEventHandler(this);
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
        }
        else
        {
            turret.StopShooting();
        }
       
    }

}

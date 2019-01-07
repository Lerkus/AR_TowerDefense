using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour {
    public enum flightstatus { landed, starting, cruising, landing}
    public flightstatus currentFlightStatus = flightstatus.landed;
    public float crusingHeight;
    private Vector3 moveTarget;
    public float flightspeed;
    public GameObject turret;
    public ParticleSystem[] thrusters;

    // Use this for initialization
    void Start () {
        thrusters = GetComponentsInChildren<ParticleSystem>();
	}

    // Update is called once per frame
    void Update() {

        Vector3 newPoint = new Vector3(0,0,0);
        Vector3 nextTarget;

        switch (currentFlightStatus)
        {
            case flightstatus.starting:
                nextTarget = new Vector3(transform.position.x, crusingHeight, transform.position.z);
                newPoint = Vector3.MoveTowards(transform.position, nextTarget, flightspeed);
                if (transform.position == nextTarget)
                    currentFlightStatus = flightstatus.cruising;
                break;
            case flightstatus.cruising:
                nextTarget = new Vector3(moveTarget.x, crusingHeight, moveTarget.z);
                newPoint = Vector3.MoveTowards(transform.position, nextTarget, flightspeed);
                if (transform.position == nextTarget)
                    currentFlightStatus = flightstatus.landing;
                break;
            case flightstatus.landing:
                nextTarget = new Vector3(moveTarget.x, 0, moveTarget.z); 
                newPoint = Vector3.MoveTowards(transform.position, nextTarget, flightspeed);
                if (transform.position == nextTarget)
                    currentFlightStatus = flightstatus.landed;
                break;
            case flightstatus.landed:
                foreach (ParticleSystem thruster in thrusters)
                    thruster.Stop();
                newPoint = gameObject.transform.position;
                break;

        }



        turret.transform.position = newPoint + turret.transform.position - gameObject.transform.position;
    }

    

    public void moveTo(Vector3 target)
    {
        if (currentFlightStatus == flightstatus.landed)
        {
            foreach (ParticleSystem thruster in thrusters)
                thruster.Play();
            currentFlightStatus = flightstatus.starting;
           
        }
        if (currentFlightStatus == flightstatus.landing && moveTarget != target)
        {
            currentFlightStatus = flightstatus.starting;
        }

        moveTarget = target;
    }
}

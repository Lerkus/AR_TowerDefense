using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class controller : MonoBehaviour, ITrackableEventHandler
{
    private bool set = false;
    private TrackableBehaviour mTrackableBehaviour;
    public PlaneFinderBehaviour p;
    // Use this for initialization
    void Start () {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetPlane()
    {
        if (!set)
        {
            set = true;
            ResetPlane();
        }
        
    }


    public void ResetPlane()
    {
        Vector2 aPosition = new Vector2(Screen.width/2, Screen.height/2);
        p.PerformHitTest(aPosition);
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if(newStatus == TrackableBehaviour.Status.TRACKED)
             SetPlane();
            //ResetPlane();
    }
}

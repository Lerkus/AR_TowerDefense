using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class tmp : MonoBehaviour,ITrackableEventHandler {

	// Use this for initialization
	void Start () {
        TrackableBehaviour mTrackableBehaviour = GetComponent<TrackableBehaviour>();

        if (mTrackableBehaviour)

        {

            mTrackableBehaviour.RegisterTrackableEventHandler(this);

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTrackableStateChanged(
                                  TrackableBehaviour.Status previousStatus,
                                  TrackableBehaviour.Status newStatus)
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
        Debug.Log("lost");
    }

    private void OnTrackingFound()
    {
        Debug.Log("found");
    }
}

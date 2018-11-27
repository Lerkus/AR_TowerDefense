using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class scr : MonoBehaviour {
    private PlaneFinderBehaviour p;
	// Use this for initialization
	void Start () {
        p = GetComponent<PlaneFinderBehaviour>();
        InvokeRepeating("replace", 2.0f, 1.0f);
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    void replace()
    {
        Vector2 aPosition = new Vector2(0, 0);
        p.PerformHitTest(aPosition);
    }
}

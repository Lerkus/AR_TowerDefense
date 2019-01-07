using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PseudoARController : MonoBehaviour {

    public GameObject[] imageTargets;
    private int CurrentTarget = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            CurrentTarget++;
            if (CurrentTarget >= imageTargets.Length)
                CurrentTarget = 0;

        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            imageTargets[CurrentTarget].transform.Translate(new Vector3(1, 0, 0));
        }
            
        if (Input.GetAxis("Horizontal") < 0)
        {
            imageTargets[CurrentTarget].transform.Translate(new Vector3(-1, 0, 0));
        }
            
        if (Input.GetAxis("Vertical") > 0)
        {
            imageTargets[CurrentTarget].transform.Translate(new Vector3(0, 0, -1));
        }
          
        if (Input.GetAxis("Vertical") < 0)
        {
            imageTargets[CurrentTarget].transform.Translate(new Vector3(0, 0, 1));
        }
          
    }
}

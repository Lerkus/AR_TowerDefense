using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class GameController : MonoBehaviour {
    
    public Camera c;
    public PlaneFinderBehaviour p;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void loose()
    {
        Time.timeScale = 0;
        Debug.Log("loose");
    }
    public static void win()
    {
        Time.timeScale = 0;
        Debug.Log("win");
    }
    
    public void replaceBoard(Vector3 nullpoint)
    {
        Vector2 aPosition = c.WorldToScreenPoint(nullpoint);
       if (p!= null)
        p.PerformHitTest(aPosition);
       
    }
    
    
}

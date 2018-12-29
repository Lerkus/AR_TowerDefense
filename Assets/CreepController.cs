using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepController : MonoBehaviour {
    public int Hitpoints;
    public float walkspeed;
    public GameObject Target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        try
        {
            gameObject.transform.LookAt(Target.transform.position);
        }
        catch (Exception ex)
        {
            if (ex is MissingReferenceException ||  ex is UnassignedReferenceException || ex is NullReferenceException)
            {
                if (GameObject.FindGameObjectsWithTag("Home").Length == 0)
                    Debug.Log("Lose");
                else
                    Target = GameObject.FindGameObjectsWithTag("Home")[0];
            }
           
        }


        move();
        



        if (Hitpoints <= 0)
        {
            GameObject.Destroy(gameObject);
        }

    }

    private void move()
    {
        try
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Target.transform.position, walkspeed);
        }
        catch (NullReferenceException e)
        {

        }
        catch (MissingReferenceException e)
        {

        }
        catch (UnassignedReferenceException e)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Home")
        {

            GameObject.Destroy(other.gameObject);
            GameObject.Destroy(gameObject);

        }
    }

}

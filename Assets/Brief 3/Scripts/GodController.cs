using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodController : MonoBehaviour
{

    //Sets which key to press.
    public KeyCode IntiateTestButton = KeyCode.Space;
    public KeyCode IntiateSpawn = KeyCode.S;

    public bool BeginSpawning = false;

    public int CurrentTarget;

    private void Start()
    {
        //CurrentTarget = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(IntiateTestButton))
        {
            ChangeTarget();
        }



        //Press Button, go to Script.
        if (Input.GetKeyDown(IntiateSpawn))
        {
            if (BeginSpawning == true)
            {
                BeginSpawning = false;
                Debug.Log("BeginSpawning = " + BeginSpawning);
            }
            else if (BeginSpawning == false)
            {
                BeginSpawning = true;
                Debug.Log("BeginSpawning = " + BeginSpawning);
            }

        }
        


    }

    void ChangeTarget()
    {
        //Add +1 to CurrentTarget.
        CurrentTarget++;
        //If CurrentTarget is Greater than the amount of Targets.
        if (CurrentTarget > GameObject.FindGameObjectsWithTag("Target").Length)
        {
            //Debug.Log("Number of Targets " + GameObject.FindGameObjectsWithTag("Target").Length);
            //Set CurrentTarget back to 1.
            CurrentTarget = 1;
        }
    }


}



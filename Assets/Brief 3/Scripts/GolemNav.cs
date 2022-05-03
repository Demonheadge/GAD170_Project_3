using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GolemNav : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;
    //Current Target to focus on.
    private int CurrentTarget;
    //Refers to the controller script.
    private GodController GodControllerScript;
    //Refers to the animator used to animate the enemy.
    [SerializeField] private Animator MonsterAnimator = null;
    //Checks to see if the enemy is at the Current Target location.
    private bool isAtTarget = false;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        //Finds the GameObject and the Script attached to it.
        GodControllerScript = GameObject.Find("God Controller").GetComponent<GodController>();

    }

    void Update()
    {
        //If the CurrentTarget Number for this script does not equal the CurrentTarget Number in the other script.
        if (CurrentTarget != GodControllerScript.CurrentTarget)
        {
            //Set the CurrentTarget Number to be the other scripts CurrentTarget Number.
            CurrentTarget = GodControllerScript.CurrentTarget;
            //Run Script, but include CurrentTarget.
            Targeting(CurrentTarget);
        }
        //Checks to see if the enemy is NOT at the CurrentTarget.
        if (isAtTarget == false)
        {
            //Set the CurrentTarget Number to be the other scripts CurrentTarget Number.
            CurrentTarget = GodControllerScript.CurrentTarget;
            //Allows the NAVMESH to move again.
            gameObject.GetComponent<NavMeshAgent>().isStopped = false;
            //Run Script, but include CurrentTarget.
            Targeting(CurrentTarget);
        }
        //Checks to see if the enemy is CURRENTLY at the CurrentTarget.
        else if (isAtTarget == true)
        {
            //Plays Idle Animation.
            MonsterAnimator.SetFloat("Walk", 0);
            //Stops the NAVMESH from moving.
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        }
        //navMeshAgent.destination = movePositionTransform.position;
    }

    void Targeting(int TargetNumber)
    {
        //Searches for all GameObjects with the Tag "Target" and puts them into an ARRAY.
        GameObject[] Target = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject i in Target)
        {
            //Checks if the GameObject contains "TargetScript" grab the TargetNumber in that script and make it equal to the TargetNumber in this script.
            if (i.GetComponent<TargetScript>().TargetNumber == TargetNumber)
            {
                Debug.Log("NOW TARGETING #" + TargetNumber);
                //Plays the Walk Animation.
                MonsterAnimator.SetFloat("Walk", 1);
                //Gets the Target GameObjects Transform Position.
                movePositionTransform = i.transform;
                //Moves Enemy Towards the Target GameObject.
                navMeshAgent.destination = movePositionTransform.position;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // check if the hitting object is the player
        if (other.gameObject.tag == "Target")
        {
            //Checks if the object that is being collided with has TargetScript, if it does check to see if it's TargetNumber equals this scripts CurrentTarget Number.
            if (other.GetComponent<TargetScript>().TargetNumber == CurrentTarget)
            {
                //Set isAtTarget to true.
                isAtTarget = true;
                //Checks to see if the ORB script is attached to the target, if it is, then check if isBeingAttacked is true.
                if (other.GetComponentInChildren<oRB>().isBeingAttacked == true)
                {
                    //Set Attack Animation.
                    MonsterAnimator.SetBool("Rage", true);
                    Debug.Log("isDestroyed = " + other.GetComponentInChildren<oRB>().isBeingAttacked);
                }
            }
            else
            {
                isAtTarget = false;
                Debug.Log("TargetNumber = " + other.GetComponent<TargetScript>().TargetNumber + ", CurrentTarget = " + CurrentTarget + ", isAtTarget = " + isAtTarget);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Target")
        {
            if (other.GetComponent<TargetScript>().TargetNumber == CurrentTarget)
            {
                isAtTarget = false;
                Debug.Log("TargetNumber = " + other.GetComponent<TargetScript>().TargetNumber + ", CurrentTarget = " + CurrentTarget + ", isAtTarget = " + isAtTarget);
            }
            Debug.Log("TargetNumber = " + other.GetComponent<TargetScript>().TargetNumber + ", CurrentTarget = " + CurrentTarget + ", isAtTarget = " + isAtTarget);
        }
    }

}

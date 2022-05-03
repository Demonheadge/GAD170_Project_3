using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;
    private int CurrentTarget;
    private GodController GodControllerScript;
    

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        GodControllerScript = GameObject.Find("God Controller").GetComponent<GodController>();

    }

    void Update()
    {
        if (CurrentTarget != GodControllerScript.CurrentTarget)
        {
            CurrentTarget = GodControllerScript.CurrentTarget;
            Targeting(CurrentTarget);
        }
        
        navMeshAgent.destination = movePositionTransform.position;

         
    }


    void Targeting(int TargetNumber)
    {
        GameObject[] Target = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject i in Target)
        {
            if (i.GetComponent<TargetScript>().TargetNumber == TargetNumber) 
            {
                Debug.Log("NOW TARGETING #" + TargetNumber);
                movePositionTransform = i.transform;
                navMeshAgent.destination = movePositionTransform.position;
            }
        }
    }

}

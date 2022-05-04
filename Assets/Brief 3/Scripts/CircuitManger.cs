using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CircuitManger : MonoBehaviour
{
    public int ActiveCircuits = 0;

    void Update()
    {
        if (ActiveCircuits <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    public void RegisterCircuit()
    {
        ActiveCircuits++;
    }

    public void DeregisterCircuit()
    {
        ActiveCircuits--;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Circuit : MonoBehaviour
{

    public UnityEvent RegisterCircuit;
    public UnityEvent DeregisterCircuit;

    // Start is called before the first frame update
    void Start()
    {
        RegisterCircuit.Invoke();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {
        DeregisterCircuit.Invoke();
    }
}
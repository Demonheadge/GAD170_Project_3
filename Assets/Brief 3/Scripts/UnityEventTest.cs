using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventTest : MonoBehaviour
{
    //public KeyCode ButtonPopper = KeyCode.T;
    public UnityEvent YouDiedScreenActive;
    public UnityEvent YouDiedScreenDeactivate;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            //CALL SCRIPT
            YouDiedScreenActive.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            //CALL SCRIPT
            YouDiedScreenDeactivate.Invoke();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarScript : MonoBehaviour
{


    [SerializeField] private int health;
    [SerializeField] private bool isBeingAttacked = false;
    [SerializeField] private bool isDestroyed = false;

    [SerializeField] private GameObject Pillar_Destroyed;


    // Start is called before the first frame update
    void Start()
    {
        health = 5000;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDestroyed == false)
        {
            if (isBeingAttacked == true)
            {
                health--;
                Debug.Log("isBeingAttacked = " + isBeingAttacked);
                Debug.Log("Health remaining = " + health);
            }
            if (health <= 0)
            {
                Debug.Log("The Pillar is Destroyed!");
                isBeingAttacked = false;
                isDestroyed = true;
                
                foreach (Transform child in this.transform)
                {
                    Destroy(child.gameObject);
                }
                


                Instantiate(Pillar_Destroyed, transform.position, transform.rotation);
            }
        }
            
    }




    private void OnTriggerEnter(Collider other)
    {

        // check if the hitting object is the player
        if (other.gameObject.tag == "Enemy")
        {
            //Debug.Log(other.gameObject.tag);
            Debug.Log("Enemy has entered the trigger zone!");
            isBeingAttacked = true;
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy has left the trigger zone!");
            isBeingAttacked = false;
            
        }
        
    }
    





















}

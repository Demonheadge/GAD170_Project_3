using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oRB : MonoBehaviour
{


    public int maxHealth;
    public HealthBar healthbar;
    [SerializeField] private int curhealth;

    [SerializeField] public bool isBeingAttacked = false;
    [SerializeField] public bool isDestroyed = false;



    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 2000;
        curhealth = maxHealth;
    }

    void Update()
    {
        if (isDestroyed == false)
        {
            if (isBeingAttacked == true)
            {
                curhealth--;
                healthbar.UpdateHealth((float)(curhealth / (float)maxHealth));
                //Debug.Log("isBeingAttacked = " + isBeingAttacked);
                //Debug.Log("Health remaining = " + health);
            }
            if (curhealth <= 0)
            {
                Debug.Log("The Orb is Destroyed!");
                isBeingAttacked = false;
                isDestroyed = true;

                foreach (Transform child in this.transform)
                {
                    Destroy(child.gameObject);
                }
            }
        }

    }


    private void OnTriggerEnter(Collider other)
    {

        // check if the hitting object is the player
        if (other.gameObject.tag == "Enemy")
        {
            if (isDestroyed == false)
            {
                Debug.Log("Enemy has entered the trigger zone!");
                isBeingAttacked = true;
            }
            else if (isDestroyed == true)
            {
                isBeingAttacked = false;
            }
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
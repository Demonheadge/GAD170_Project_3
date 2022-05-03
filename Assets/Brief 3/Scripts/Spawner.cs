using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //How many enemies are currently spawned from this spawner.
    [SerializeField] private int curSpawned;
    //How many enemies can spawn from this spawner.
    [SerializeField] private int maxSpawned;
    //How long between each enemy spawning.
    [SerializeField] private float SpawnTimer;
    [SerializeField] private float SpawnTimerLength = 2;
    //List on enemies.
    //
    //Is the spawner active.
    //




    // Start is called before the first frame update
    void Start()
    {
        //GodController sn = gameObject.GetComponent<GodController>()
        //sn.BeginSpawning();
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    /// <summary>
    /// SPAWNING SCRIPT
    /// </summary>
    //Determine the enemy object.
    [SerializeField] private GameObject enemy;
    void Spawn()
    {
        //if (BeginSpawning == true)
        //{

            SpawnTimer -= Time.deltaTime;


            //If Timer = 0 and there are less than the maximum objects spawned.
            if (SpawnTimer <= 0f && curSpawned < maxSpawned)
            {
                //Debug.Log("Spawning has begun.");
                //Adds to the current amount spawned.
                curSpawned++;
                //Resets the spawn timer.
                SpawnTimer = SpawnTimerLength;
                //Creates an object at specific postition and rotation.
                Instantiate(enemy, transform.position, transform.rotation);
            }
            else if (SpawnTimer <= 0f && curSpawned == maxSpawned)
            {
                //Debug.Log("There is nothing to spawn.");
                SpawnTimer = SpawnTimerLength;
            }

        //}

    }
}





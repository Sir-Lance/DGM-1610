using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIFollow : MonoBehaviour
{
    public NavMeshAgent agent;
    private AIHealth health;
    public GameObject spawnPoint;
    public GameObject healthPack;
    Rigidbody u_AI;
    public float randomSpeed;
    public float randBoool;
    bool alive;
    bool toggle;

    void Awake()  
    {

        health = GetComponent<AIHealth>();
    }

    void Start()
    {
        randBoool = Random.Range(0f, 1f);
        randomSpeed = Random.Range(5.0f , 16.0f);
        agent.speed = randomSpeed;
        alive = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(health.AIuHealth <= 0)
        {
            alive = false;
        }
        
        if(health.AIuHealth >= 0);
        {
            if(agent.enabled == true && alive)
            {
                agent.SetDestination(GameObject.Find("MBTHull").transform.position);
            }
            if(agent.enabled == false && alive)
            {
                u_AI = GetComponent<Rigidbody>();
                u_AI.mass = 3000;
            }
        }

        if(health.AIuHealth <= 0)
        {
            agent.enabled = false;
            u_AI = GetComponent<Rigidbody>();
            u_AI.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;;
            if(!alive && !toggle)
            {
                toggle = true;
                GameObject pickup = Instantiate(healthPack, spawnPoint.transform.position, spawnPoint.transform.rotation);
                Destroy(pickup, 15f);
            }
        }

        //round start determines whether it hunts you or you hunt it.
        if(randBoool > 0.5f)
        {
            agent.enabled = false;
        }
    }
}

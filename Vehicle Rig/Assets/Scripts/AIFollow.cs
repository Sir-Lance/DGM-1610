using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIFollow : MonoBehaviour
{
    public NavMeshAgent agent;
    private AIHealth health;
    Rigidbody u_AI;
    public float randomSpeed;

    void Awake()  
    {
        health = GetComponent<AIHealth>();
    }

    void Start()
    {
        randomSpeed = Random.Range(5.0f , 16.0f);
        agent.speed = randomSpeed;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(health.AIuHealth >= 0)
        {
            agent.SetDestination(GameObject.Find("MBTHull").transform.position);
        }

        if(health.AIuHealth <= 0)
        {
            agent.enabled = false;
            u_AI = GetComponent<Rigidbody>();
            u_AI.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;;
        }
    }
}

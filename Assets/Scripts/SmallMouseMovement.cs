using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SmallMouseMovement : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    private bool PlayerInRange = false;
    // Start is called before the first frame update
    void Start()
    {
        //UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //agent.destination = goal.position;

        //agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInRange){
            agent.destination = player.position;
        }

        //agent.SetDestination(player.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "PlayerObj")
        {
            PlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "PlayerObj")
        {
            PlayerInRange = false;
        }
    }
}

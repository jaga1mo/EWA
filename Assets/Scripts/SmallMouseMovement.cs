using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SmallMouseMovement : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    private bool PlayerInRange = false;
    public GameObject SpawnSound;
    // Start is called before the first frame update
    void Start()
    {
        SpawnSound.SetActive(false);
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
            SpawnSound.SetActive(true);
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

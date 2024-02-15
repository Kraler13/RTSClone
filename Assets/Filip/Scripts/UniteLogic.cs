using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UniteLogic : MonoBehaviour
{
    private SquadLogic squadLogic;
    private NavMeshAgent navMeshAgent;
    private GameObject pointToFollow;

    void Start()
    {
        squadLogic = GetComponentInParent<SquadLogic>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = squadLogic.SquadSpeed;        
        pointToFollow = squadLogic.ListOfSpowningPoints[0];
        squadLogic.ListOfSpowningPoints.RemoveAt(0);
    }

    void Update()
    {
        navMeshAgent.SetDestination(pointToFollow.transform.position);
    }
}

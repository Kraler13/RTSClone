using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SquadLogic : MonoBehaviour
{
    public List<GameObject> ListOfSpowningPoints;
    public List<GameObject> ListOfSpowningPointsToChange;
    public float SquadSpeed = 10f;
    private NavMeshAgent navMeshAgent;
    [SerializeField] private float RotationSpeed = 360f;

    void Start()
    {
        foreach (GameObject p in ListOfSpowningPoints)
        {
           ListOfSpowningPointsToChange.Add(p);
        }           
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = SquadSpeed;
        navMeshAgent.angularSpeed = RotationSpeed;
    }
    public void MoveToDestination(Vector3 destination)
    {
        Vector3 direction = destination - transform.position;
        navMeshAgent.SetDestination(destination);
    }
}

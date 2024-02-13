using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SquadLogic : MonoBehaviour
{

    public float SquadSpeed = 10f;
    private NavMeshAgent navMeshAgent;
    [SerializeField] private float RotationSpeed = 360f;
    private InputMenager inputMenager;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = SquadSpeed;
        navMeshAgent.angularSpeed = RotationSpeed;
        inputMenager = GameObject.FindGameObjectWithTag("LvlMenager").GetComponent<InputMenager>();
    }
    public void MoveToDestination(Vector3 destination)
    {
        Vector3 direction = destination - transform.position;
        navMeshAgent.SetDestination(destination);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UniteLogic : MonoBehaviour
{
    public float speed;
    public float endurance;
    [SerializeField] private InputMenager inputMenager;
    private NavMeshAgent navMeshAgent;
    private float RotationSpeed = 360f;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        
    }

    public void MoveToDestination(Vector3 destination)
    {
        navMeshAgent.SetDestination(destination);
    }
}

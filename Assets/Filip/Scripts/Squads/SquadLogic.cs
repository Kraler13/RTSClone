using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SquadLogic : MonoBehaviour
{
    public List<GameObject> ListOfSpowningPoints;
    public List<GameObject> ListOfSpowningPointsToChange;
    public float SquadSpeed = 10f;
    public bool IsSquadChosen = false;
    public bool IsLeftClicked = false;
    private NavMeshAgent navMeshAgent;
    [SerializeField] private float RotationSpeed = 360f;

    void Start()
    {
        var HUD = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDMenager>().ActionButtons;
        HUD[0].onClick.AddListener(() => ButtonOneLeft());

        EventTrigger triggerRight = HUD[0].gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entryRight = new EventTrigger.Entry();
        entryRight.eventID = EventTriggerType.PointerDown;
        entryRight.callback.AddListener((eventData) => ButtonActionRight());
        triggerRight.triggers.Add(entryRight);

        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = SquadSpeed;
        navMeshAgent.angularSpeed = RotationSpeed;
    }

    public void ButtonOneLeft()
    {
        IsLeftClicked = true;
        Debug.Log("lewy");
        IsLeftClicked = false;

    }

    public void ButtonActionRight()
    { 
        if (!IsLeftClicked) 
        Debug.Log("prawy");
    }

    public void MoveToDestination(Vector3 destination)
    {
        Vector3 direction = destination - transform.position;
        navMeshAgent.SetDestination(destination);
    }
}

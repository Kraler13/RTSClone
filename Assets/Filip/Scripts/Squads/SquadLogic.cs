using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//przypisujemy do ka�dego sqadu
//bierzemy z t�d punkty za kt�rymi nale�y pot��a� dla jednostki
//przypisujemy odpowiedni Button do danej jednostki
public class SquadLogic : MonoBehaviour
{
    public GameObject Unite;
    public Sprite SquadImage;
    public Button SquadButtonPrefab;
    public List<GameObject> ListOfSpowningPoints;
    public List<GameObject> ListOfSpowningPointsToChange;
    public float SquadSpeed = 10f;
    public bool IsSquadChosen = false;
    public bool IsCaptureingAPoint = false;
    public ResorsSriptableObj resorsSriptableObj;
    [SerializeField] private float RotationSpeed = 360f;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
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

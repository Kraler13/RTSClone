using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class InputMenager : MonoBehaviour
{
    [SerializeField] SelectDictionary SelectDictionary;
    [SerializeField] private float distanceBetweenSquads = 5;
    [SerializeField] private List<GameObject> list;
    private List<Vector3> listOfPoints = new List<Vector3>();

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        var table = SelectDictionary.selectedTable;
        if (Input.GetMouseButtonDown(1) && table.Count != 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                foreach (KeyValuePair<int, GameObject> gO in SelectDictionary.selectedTable)
                {
                    list.Add(gO.Value);
                }
                MathfHendle(hit.point);
                //dodaæ if w momêcie ataku
                for (int i = 0; i < SelectDictionary.selectedTable.Count; i++)
                {
                    list[i].GetComponent<SquadLogic>().MoveToDestination(listOfPoints[i]);
                }
            }
            list.Clear();
            listOfPoints.Clear();
        }
    }
    void MathfHendle(Vector3 hitPointValue)
    {
        Vector3 pointA = list[0].transform.position;
        Vector3 pointB = hitPointValue;
        float radius = Vector3.Distance(pointB, pointA);
        Vector3 vectorAB = pointB - pointA;
        Vector3 normalizedAB = vectorAB.normalized;
        Vector3 offset = distanceBetweenSquads * normalizedAB;
        

        listOfPoints.Add(pointB);
        listOfPoints.Add(pointB + distanceBetweenSquads * new Vector3(normalizedAB.x, 0, -normalizedAB.z));
        listOfPoints.Add(pointB - distanceBetweenSquads * new Vector3(normalizedAB.x, 0, -normalizedAB.z));
        listOfPoints.Add(pointB - offset);
        listOfPoints.Add(pointB - offset + distanceBetweenSquads * new Vector3(normalizedAB.x, 0, -normalizedAB.z));
        listOfPoints.Add(pointB - offset - distanceBetweenSquads * new Vector3(normalizedAB.x, 0, -normalizedAB.z));
        listOfPoints.Add(pointB - offset * 2);
        listOfPoints.Add(pointB - offset * 2 + distanceBetweenSquads * new Vector3(normalizedAB.x, 0, -normalizedAB.z));
        listOfPoints.Add(pointB - offset * 2 - distanceBetweenSquads * new Vector3(normalizedAB.x, 0, -normalizedAB.z));
        int k = 0;
        foreach (var point in listOfPoints)
        {
            Debug.Log(point);
            Debug.Log("punkt " + k);
            k++;
        }

       

    }
}





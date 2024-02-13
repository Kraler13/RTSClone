using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMenager : MonoBehaviour
{
    public SquadLogic squad;
    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                squad.MoveToDestination(hit.point);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    [SerializeField] private ActionButtonsScriptableObj ActionButtonsScriptableObj;
    private SquadLogic squadLogic;
    // Start is called before the first frame update
    void Start()
    {
        squadLogic = gameObject.GetComponent<SquadLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (squadLogic.IsSquadChosen)
        {
            ActionButtonsScriptableObj.buttons[0].GetComponentInChildren<TextMeshProUGUI>().text = "";
        }
    }
}

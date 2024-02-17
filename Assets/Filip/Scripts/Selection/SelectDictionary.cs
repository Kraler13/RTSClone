using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class SelectDictionary : MonoBehaviour
{
    public Dictionary<int, GameObject> selectedTable = new Dictionary<int, GameObject>();
    [SerializeField] private Image HUDCaracterTab;
    private List<Button> buttonList = new List<Button>();
    public void addSelected(GameObject go)
    {
        int id = go.GetInstanceID();

        if (!(selectedTable.ContainsKey(id)) && go.gameObject.tag == "Squad")
        {
            selectedTable.Add(id, go);
            go.AddComponent<SelectionHelper>();
            foreach (KeyValuePair<int, GameObject> item in selectedTable)
            {
                var createdButton = Instantiate(item.Value.GetComponent<SquadLogic>().SquadButtonPrefab, HUDCaracterTab.transform);
                buttonList.Add(createdButton);
            }
            Debug.Log("Added " + id + " to selected dict");
            Debug.Log(selectedTable.Count);
        }
    }

    public void deselect(int id)
    {
        Destroy(selectedTable[id].GetComponent<SelectionHelper>());
        selectedTable.Remove(id);
    }

    public void deselectAll()
    {
        foreach (KeyValuePair<int, GameObject> pair in selectedTable)
        {
            if (pair.Value != null)
            {
                Destroy(selectedTable[pair.Key].GetComponent<SelectionHelper>());
                foreach (var item in buttonList)
                {
                    Destroy(item.gameObject);
                }
                buttonList.Clear();

            }
        }
        selectedTable.Clear();
    }
}

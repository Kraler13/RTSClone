using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HUDMenager : MonoBehaviour/*, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler*/
{
    public List<Button> ActionButtons;

    [SerializeField] private List<GameObject> heroObj;
    [SerializeField] private CameraManager CameraMenager;
    [SerializeField] private InputMenager InputMenager;

    private List<HUDMenager> ButtonAction;
    private GameObject hoveredHero;
    private int k = 0;
    void Start()
    {
        
    }
    void Update()
    {
        if (hoveredHero != null)
        {
            foreach (var hero in heroObj)
            {
                InputMenager.enabled = false;
            }
            k = 1;
        }
        else if (hoveredHero == null && k == 1)
        {
            foreach (var hero in heroObj)
            {
                InputMenager.enabled = true;
            }
            k = 0;
        }
    }

    void SelectHero(GameObject selectedHero)
    {
        //CameraMenager.target = selectedHero.transform;

        //Hero heroComponent = selectedHero.GetComponent<Hero>();
        //FollowerScript followerComponent = selectedHero.GetComponent<FollowerScript>();
        //heroComponent.enabled = true;
        //followerComponent.enabled = false;
        //if (heroComponent != null)
        //{
        //    InputMenager.hero = heroComponent;
        //}
        //int i = 0;
        //foreach (var hero in heroObj)
        //{
        //    if (hero != selectedHero)
        //    {
        //        hero.GetComponent<Hero>().enabled = false;
        //        hero.GetComponent<FollowerScript>().enabled = true;
        //        hero.GetComponent<FollowerScript>().PointToFollowNow = followerComponent.FollowPoints[i];
        //        i++;
        //    }
        //}
    }
    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    hoveredHero = eventData.pointerEnter;
    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    hoveredHero = null;
    //}

    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    throw new System.NotImplementedException();
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SubberDropDownScript : MonoBehaviour, IControllerInteractable
{
    public string outputCountry;
    public int outputYear;
    public CountryEvent clickedFunction;
    public UnityEvent<string, int> a;

    public void adwjadja(string s, int a)
    {

    }

    public bool visible;

    public void Show()
    {
        visible = true;
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        visible = false;
        gameObject.SetActive(false);
    }

    public void Hover()
    {

    }

    public void EndHover()
    {

    }

    public void Click()
    {

    }

    public void EndClick()
    {

    }

    public void HoverToClick()
    {

    }

    public void ClickToHover()
    {
        throw new System.NotImplementedException();
    }
}

public class CountryEvent : UnityEvent<string, int>
{
}

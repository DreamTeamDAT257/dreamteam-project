using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SubberDropDownScript : BaseButtonScript
{
    public string outputCountry;
    public int outputYear;

    public bool visible;
    public bool selected;

    public Material selectedDefaultMaterial;
    public Material selectedHoverMaterial;
    public Material selectedClickMaterial;

    public void Selected()
    {
        selected = true;
    }

    public void Unselected()
    {
        selected = false;
    }

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

    public override void UninteractButton()
    {

        if (selected)
        {
            meshRender.material = selectedDefaultMaterial;
        }
        else
        {
            base.UninteractButton();
        }
    }

    public override void HoveringButton()
    {
        if (selected)
        {
            meshRender.material = selectedHoverMaterial;
        }
        else
        {
            base.HoveringButton();
        }
    }

    public override void ClickingButton()
    {
        if (selected)
        {
            meshRender.material = selectedClickMaterial;
        }
        else
        {
            base.ClickingButton();
        }
    }

    public override void ClickToHover()
    {
        if (visible)
        {
            triggerEvent.Invoke(this);
        }
        HoveringButton();
    }
}

public class CountryEvent : UnityEvent<string, int>
{
}

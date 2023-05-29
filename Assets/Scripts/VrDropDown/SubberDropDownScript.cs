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

    
    /**Selects option**/
    public void Selected()
    {
        selected = true;
    }

    /**Unselects option**/
    public void Unselected()
    {
        selected = false;
         UninteractButton();
    }

    /**Displays option**/
    public void Show()
    {
        visible = true;
        gameObject.SetActive(true);
    }

    /**Hides option**/
    public void Hide()
    {
        visible = false;
        gameObject.SetActive(false);
    }

    // Expanded the change state methods to allow for additional materials if it is selected
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainDropDownScript : MonoBehaviour, IControllerInteractable
{
    public void Testing(string name, int year)
    {
        Debug.Log(name);
        Debug.Log(year);
    }


    public SubberDropDownScript[] subbs;
    public bool Dropped;

    public UnityEvent<string, int> onNewSelection;

    private SubberDropDownScript currentSelected;

    public void PullUp()
    {
        foreach (SubberDropDownScript subb in subbs)
        {
            subb.Hide();
        }
        Dropped = false;
    }

    public void Drop()
    {
        foreach (SubberDropDownScript subb in subbs)
        {
            subb.Show();
        }
        Dropped = true;
    }


    public void NewSelection(BaseButtonScript selectedBackReferance)
    {
        if (currentSelected == selectedBackReferance)
        {
            return;
        }

        if (currentSelected != null)
        {
            currentSelected.Unselected();
        }

        currentSelected = ((SubberDropDownScript)selectedBackReferance);

        onNewSelection.Invoke(currentSelected.outputCountry, currentSelected.outputYear);

        currentSelected.Selected();
    }


    public void Click()
    {
        
    }

    public void ClickToHover()
    {
        
    }

    public void EndClick()
    {
        
    }

    public void EndHover()
    {
        
    }

    public void Hover()
    {
        
    }

    public void HoverToClick()
    {
        if (Dropped)
        {
            PullUp();
        }
        else
        {
            Drop();
        }
    }
}

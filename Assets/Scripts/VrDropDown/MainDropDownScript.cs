using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainDropDownScript : MonoBehaviour, IControllerInteractable
{
    public SubberDropDownScript[] subbs;
    public bool Dropped;

    public UnityEvent<string> onNewSelection;

    private SubberDropDownScript currentSelected;

    public float moveOnOpen;


    /**Pulls up dropdown menu**/
    public void PullUp()
    {
        transform.position = transform.position + new Vector3(0, -moveOnOpen, 0);
        foreach (SubberDropDownScript subb in subbs)
        {
            subb.Hide();
        }
        Dropped = false;
    }

    /**Pulls down dropdown menu**/
    public void Drop()
    {
        transform.position = transform.position + new Vector3(0, moveOnOpen, 0);
        foreach (SubberDropDownScript subb in subbs)
        {
            subb.Show();
        }
        Dropped = true;
    }


    /**Called when a new selection is made, sends selection to listeners**/
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

        onNewSelection.Invoke(currentSelected.outputCountry);

        currentSelected.Selected();
    }


    #region interface implementation
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
    #endregion
}

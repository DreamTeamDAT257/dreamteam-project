using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDropDownScript : MonoBehaviour, IControllerInteractable
{
    public SubberDropDownScript[] subbs;
    public bool Dropped;

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

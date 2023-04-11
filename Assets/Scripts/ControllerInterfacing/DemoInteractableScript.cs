using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoInteractableScript : MonoBehaviour , IControllerInteractable
{
    public void Click()
    {
        Debug.Log("Clicking");
    }

    public void ClickToHover()
    {
        Debug.Log("Hovering");
    }

    public void EndClick()
    {
        Debug.Log("Stopped clicking");
    }

    public void EndHover()
    {
        Debug.Log("Stopped hovering");
    }

    public void Hover()
    {
        Debug.Log("Hovering");
    }

    public void HoverToClick()
    {
        Debug.Log("Clicking");
    }
}

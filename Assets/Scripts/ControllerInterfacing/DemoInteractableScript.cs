using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoInteractableScript : MonoBehaviour , IControllerInteractable
{
    public bool clicked;
    public bool hovered;

    public void Click()
    {
        clicked = true;
    }

    public void ClickToHover()
    {
        clicked = false;
        hovered = true;
    }

    public void EndClick()
    {
        clicked = false;
    }

    public void EndHover()
    {
        hovered = false;
    }

    public void Hover()
    {
        hovered = true;
    }

    public void HoverToClick()
    {
        clicked = true;
        hovered = false;



    }

    private void FixedUpdate()
    {
        if (hovered)
        {
            //transform.position = new Vector3(0.1f, 0, 0) + transform.position;

        }
        if (clicked)
        {
            //transform.position = new Vector3(-0.1f, 0, 0) + transform.position;
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}

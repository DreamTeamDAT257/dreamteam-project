using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SendToSceneButtonScript : MonoBehaviour, IControllerInteractable
{
    public Color defaultColor;
    public Color hoverColor;
    public Color clickColor;
    public Material buttonMaterial;
    public int toScene = 1;

    public void UninteractButton()
    {
        buttonMaterial.SetColor("_Color", defaultColor);
    }

    public void HoveringButton()
    {
        buttonMaterial.SetColor("_Color", hoverColor);
    }

    public void ClickingButton()
    {
        buttonMaterial.SetColor("_Color", clickColor);
    }


    #region interface implementation
    public void Click()
    {
        ClickingButton();
    }

    public void ClickToHover()
    {
        SceneManager.LoadScene(toScene);
    }

    public void EndClick()
    {
        UninteractButton();
    }

    public void EndHover()
    {
        UninteractButton();
    }

    public void Hover()
    {
        HoveringButton();
    }

    public void HoverToClick()
    {
        ClickingButton();
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenuScript : MonoBehaviour, IControllerInteractable
{
    public GameObject button;
    public static readonly int mainMenuScene = 0;

    public void HoveringButton()
    {
        button.transform.localScale = new Vector3(0.6f, 1, 1);
    }

    public void ClickingButton()
    {
        button.transform.localScale = new Vector3(0.2f, 1, 1);
    }

    public void UninteractButton()
    {
        button.transform.localScale = new Vector3(1, 1, 1);
    }


    #region interface implementation
    public void Click()
    {
        ClickingButton();
    }

    public void ClickToHover()
    {
        SceneManager.LoadScene(mainMenuScene);
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

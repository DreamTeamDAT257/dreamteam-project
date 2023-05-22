using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseButtonScript : MonoBehaviour, IControllerInteractable
{
    public UnityEvent<BaseButtonScript> triggerEvent;

    public Material defaultMaterial;
    public Material hoverMaterial;
    public Material clickMaterial;
    public MeshRenderer meshRender;


    /**UninteractButton is called when the user stops either hovering or clicking on the button**/
    public virtual void UninteractButton()
    {
        meshRender.material = defaultMaterial;
    }

    /**HoveringButton is called when the user hovers the button**/
    public virtual void HoveringButton()
    {
        meshRender.material = hoverMaterial;
    }

    /**ClickingButton is called when the user clicks the button**/
    public virtual void ClickingButton()
    {
        meshRender.material = clickMaterial;
    }



    #region interface implementation
    public virtual void Click()
    {
        ClickingButton();
    }

    public virtual void ClickToHover()
    {
        triggerEvent.Invoke(this);
        HoveringButton();
    }

    public virtual void EndClick()
    {
        UninteractButton();
    }

    public virtual void EndHover()
    {
        UninteractButton();
    }

    public virtual void Hover()
    {
        HoveringButton();
    }

    public virtual void HoverToClick()
    {
        ClickingButton();
    }
    #endregion
}
